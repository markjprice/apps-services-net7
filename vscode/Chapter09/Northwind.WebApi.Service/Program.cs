using AspNetCoreRateLimit; // ClientRateLimitOptions, ClientRateLimitPolicies
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http.HttpResults; // Results
using Microsoft.AspNetCore.HttpLogging; // HttpLoggingFields
using Microsoft.AspNetCore.Mvc; // [FromServices]
using Microsoft.AspNetCore.OpenApi; // WithOpenApi
using Microsoft.AspNetCore.RateLimiting; // UseRateLimiter, RateLimiterOptions
using Microsoft.Extensions.Configuration;
using Packt.Shared; // AddNorthwindContext extension method
using System.Threading.RateLimiting; // PartitionedRateLimiter

var builder = WebApplication.CreateBuilder(args);

// AspNetCoreRateLimit rate limiting middleware

// needed to store rate limit counters and rules
builder.Services.AddMemoryCache();
builder.Services.AddInMemoryRateLimiting();

// load default rate limit options from appsettings.json
builder.Services.Configure<ClientRateLimitOptions>(
  builder.Configuration.GetSection("ClientRateLimiting"));

// load client-specific policies from appsettings.json
builder.Services.Configure<ClientRateLimitPolicies>(
  builder.Configuration.GetSection("ClientRateLimitPolicies"));

// register configuration
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

string northwindMvc = "Northwind.Mvc.Policy";

builder.Services.AddCors(options =>
{
  options.AddPolicy(name: northwindMvc,
    policy =>
    {
      policy.WithOrigins("https://localhost:5092");
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddNorthwindContext();

builder.Services.AddHttpLogging(options =>
{
  // if we do not explicitly add the Origin header
  // it will be redacted
  options.RequestHeaders.Add("Origin");

  // if we do not explicitly add the rate limiting headers
  // they will be redacted
  options.RequestHeaders.Add("X-Client-Id");
  options.ResponseHeaders.Add("Retry-After");

  // by default the response body is not included
  options.LoggingFields = HttpLoggingFields.All;
});

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
  IClientPolicyStore clientPolicyStore = scope.ServiceProvider
    .GetRequiredService<IClientPolicyStore>();

  await clientPolicyStore.SeedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpLogging();

app.UseClientRateLimiting();

// app.UseCors(policyName: northwindMvc);

// without a named policy the middleware is added but not active
app.UseCors();

app.MapGet("/", () => "Hello World!")
  .ExcludeFromDescription();

int pageSize = 10;

app.MapGet("api/products", (
  [FromServices] NorthwindContext db,
  [FromQuery] int? page) =>
  db.Products.Where(product =>
    (product.UnitsInStock > 0) && (!product.Discontinued))
    .Skip(((page ?? 1) - 1) * pageSize).Take(pageSize)
  )
  .WithName("GetProducts")
  .WithOpenApi(operation =>
  {
    operation.Description =
      "Get products with UnitsInStock > 0 and Discontinued = false.";
    operation.Summary = "Get in-stock products that are not discontinued.";
    return operation;
  })
  .Produces<Product[]>(StatusCodes.Status200OK);

app.MapGet("api/products/outofstock", ([FromServices] NorthwindContext db) =>
  db.Products.Where(product =>
    (product.UnitsInStock == 0) && (!product.Discontinued)))
  .WithName("GetProductsOutOfStock")
  .WithOpenApi()
  .Produces<Product[]>(StatusCodes.Status200OK);

app.MapGet("api/products/discontinued", ([FromServices] NorthwindContext db) =>
  db.Products.Where(product => product.Discontinued))
  .WithName("GetProductsDiscontinued")
  .WithOpenApi()
  .Produces<Product[]>(StatusCodes.Status200OK);

app.MapGet("api/products/{id:int}",
  async Task<Results<Ok<Product>, NotFound>> (
  [FromServices] NorthwindContext db,
  [FromRoute] int id) =>
    await db.Products.FindAsync(id) is Product product ?
      TypedResults.Ok(product) : TypedResults.NotFound())
  .WithName("GetProductById")
  .WithOpenApi()
  .Produces<Product>(StatusCodes.Status200OK)
  .Produces(StatusCodes.Status404NotFound)
  .RequireCors(policyName: northwindMvc);

app.MapGet("api/products/{name}", (
  [FromServices] NorthwindContext db,
  [FromRoute] string name) =>
    db.Products.Where(p => p.ProductName.Contains(name)))
  .WithName("GetProductsByName")
  .WithOpenApi()
  .Produces<Product[]>(StatusCodes.Status200OK)
  .RequireCors(policyName: northwindMvc);

app.MapPost("api/products", async (
  [FromBody] Product product,
  [FromServices] NorthwindContext db) =>
{
  db.Products.Add(product);
  await db.SaveChangesAsync();
  return Results.Created($"api/products/{product.ProductId}", product);
}).WithOpenApi()
  .Produces<Product>(StatusCodes.Status201Created);

app.MapPut("api/products/{id:int}", async (
  [FromRoute] int id,
  [FromBody] Product product,
  [FromServices] NorthwindContext db) =>
{
  Product? foundProduct = await db.Products.FindAsync(id);

  if (foundProduct is null) return Results.NotFound();

  foundProduct.ProductName = product.ProductName;
  foundProduct.CategoryId = product.CategoryId;
  foundProduct.SupplierId = product.SupplierId;
  foundProduct.QuantityPerUnit = product.QuantityPerUnit;
  foundProduct.UnitsInStock = product.UnitsInStock;
  foundProduct.UnitsOnOrder = product.UnitsOnOrder;
  foundProduct.ReorderLevel = product.ReorderLevel;
  foundProduct.UnitPrice = product.UnitPrice;
  foundProduct.Discontinued = product.Discontinued;

  await db.SaveChangesAsync();

  return Results.NoContent();
}).WithOpenApi()
  .Produces(StatusCodes.Status404NotFound)
  .Produces(StatusCodes.Status204NoContent);

app.MapDelete("api/products/{id:int}", async (
  [FromRoute] int id,
  [FromServices] NorthwindContext db) =>
{
  if (await db.Products.FindAsync(id) is Product product)
  {
    db.Products.Remove(product);
    await db.SaveChangesAsync();
    return Results.NoContent();
  }
  return Results.NotFound();
}).WithOpenApi()
  .Produces(StatusCodes.Status404NotFound)
  .Produces(StatusCodes.Status204NoContent);

// ASP.NET Core rate limiting middleware
/*
app.UseRateLimiter(new RateLimiterOptions
{
  Limiter = PartitionedRateLimiter.Create<HttpContext, string>(resource =>
  {
    return RateLimitPartition.CreateConcurrencyLimiter("OneLimiter",
        _ => new ConcurrencyLimiterOptions(
          permitLimit: 1, QueueProcessingOrder.NewestFirst,
          queueLimit: 1));
  })
});
*/

app.Run();
