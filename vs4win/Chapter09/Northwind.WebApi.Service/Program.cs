using AspNetCoreRateLimit; // ClientRateLimitOptions, ClientRateLimitPolicies
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http.HttpResults; // Results
using Microsoft.AspNetCore.HttpLogging; // HttpLoggingFields
using Microsoft.AspNetCore.Mvc; // [FromServices]
using Microsoft.AspNetCore.OpenApi; // WithOpenApi
using Microsoft.AspNetCore.RateLimiting; // RateLimiterOptions
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Packt.Shared; // AddNorthwindContext extension method
using System.Threading.RateLimiting; // FixedWindowRateLimiterOptions
using System.Security.Claims; // ClaimsPrincipal

bool useMicrosoftRateLimiting = true;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(defaultScheme: "Bearer")
  .AddJwtBearer();

// Configure AspNetCoreRateLimit rate limiting middleware.
if (!useMicrosoftRateLimiting)
{
  // Add services to store rate limit counters and rules.
  builder.Services.AddMemoryCache();
  builder.Services.AddInMemoryRateLimiting();

  // Load default rate limit options from appsettings.json.
  builder.Services.Configure<ClientRateLimitOptions>(
    builder.Configuration.GetSection("ClientRateLimiting"));

  // Load client-specific policies from appsettings.json.
  builder.Services.Configure<ClientRateLimitPolicies>(
    builder.Configuration.GetSection("ClientRateLimitPolicies"));

  // Register the configuration.
  builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
}

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
  // Add the Origin header so it will not be redacted.
  options.RequestHeaders.Add("Origin");

  // Add the rate limiting headers so they will not be redacted.
  options.RequestHeaders.Add("X-Client-Id");
  options.ResponseHeaders.Add("Retry-After");

  // By default, the response body is not included.
  options.LoggingFields = HttpLoggingFields.All;
});

var app = builder.Build();

app.UseAuthorization();

if (!useMicrosoftRateLimiting)
{
  using (IServiceScope scope = app.Services.CreateScope())
  {
    IClientPolicyStore clientPolicyStore = scope.ServiceProvider
      .GetRequiredService<IClientPolicyStore>();

    await clientPolicyStore.SeedAsync();
  }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpLogging();

if (!useMicrosoftRateLimiting)
{
  app.UseClientRateLimiting();
}

// app.UseCors(policyName: northwindMvc);

// without a named policy the middleware is added but not active
app.UseCors();

app.MapGet("/", () => "Hello World!")
  .ExcludeFromDescription();

app.MapGet("/secret", (ClaimsPrincipal user) => 
  $"Hello {user.Identity?.Name}. The secret ingredient is love.")
  .RequireAuthorization();

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
  .Produces<Product[]>(StatusCodes.Status200OK)
  .RequireRateLimiting("fixed5per10seconds");

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

// Configure ASP.NET Core rate limiting middleware.
if (useMicrosoftRateLimiting)
{
  RateLimiterOptions rateLimiterOptions = new();

  rateLimiterOptions.AddFixedWindowLimiter(
    policyName: "fixed5per10seconds", options =>
    {
      options.PermitLimit = 5;
      options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
      options.QueueLimit = 2;
      options.Window = TimeSpan.FromSeconds(10);
    });

  app.UseRateLimiter(rateLimiterOptions);
}

app.Run();
