using Microsoft.AspNetCore.Mvc; // [FromServices] 
using Packt.Shared; // AddNorthwindContext extension method
using System.Text.Json.Serialization; // ReferenceHandler
using System.Text.Json; // JsonSerializerOptions

var builder = WebApplication.CreateBuilder(args);

// This should work to set default options for JSON
// serialization but it seems to be ignored.
builder.Services.Configure<JsonOptions>(options =>
{
  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
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

// Create an options object to pass with Results.Json
JsonSerializerOptions jsonOptions = new()
{
  // Employee entity has circular reference to itself so
  // we must control how references are handled.
  ReferenceHandler = ReferenceHandler.Preserve
};

app.MapGet("api/employees", (
  [FromServices] NorthwindContext db) => 
    Results.Json(db.Employees, jsonOptions))
  .WithName("GetEmployees")
  .Produces<Employee[]>(StatusCodes.Status200OK);

app.MapGet("api/employees/{country}", (
  [FromServices] NorthwindContext db,
  [FromRoute] string country) =>
    Results.Json(db.Employees.Where(employee => 
    employee.Country == country), jsonOptions))
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
