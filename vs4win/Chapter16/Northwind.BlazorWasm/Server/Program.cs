using Microsoft.AspNetCore.Mvc; // [FromServices] 
using Packt.Shared; // AddNorthwindContext extension method
using System.Text.Json.Serialization; // ReferenceHandler

// define an alias for the JsonOptions class
using HttpJsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<HttpJsonOptions>(options =>
{
  options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddNorthwindContext();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseWebAssemblyDebugging();
}
else
{
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapGet("api/employees", (
  [FromServices] NorthwindContext db) => 
    Results.Json(db.Employees))
  .WithName("GetEmployees")
  .Produces<Employee[]>(StatusCodes.Status200OK);

app.MapGet("api/employees/{id:int}", (
  [FromServices] NorthwindContext db,
  [FromRoute] int id) =>
  {
    Employee? employee = db.Employees.Find(id);
    if (employee == null)
    {
      return Results.NotFound();
    }
    else
    {
      return Results.Json(employee);
    }
  })
  .WithName("GetEmployeesById")
  .Produces<Employee>(StatusCodes.Status200OK)
  .Produces(StatusCodes.Status404NotFound);

app.MapGet("api/employees/{country}", (
  [FromServices] NorthwindContext db,
  [FromRoute] string country) =>
    Results.Json(db.Employees.Where(employee => 
    employee.Country == country)))
  .WithName("GetEmployeesByCountry")
  .Produces<Employee[]>(StatusCodes.Status200OK);

app.MapPost("api/employees", async (
  [FromBody] Employee employee,
  [FromServices] NorthwindContext db) =>
  {
    db.Employees.Add(employee);
    await db.SaveChangesAsync();
    return Results.Created($"api/employees/{employee.EmployeeId}", employee);
  })
  .Produces<Employee>(StatusCodes.Status201Created);

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
