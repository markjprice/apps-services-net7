using Microsoft.AspNetCore.Mvc; // [FromServices]
using Packt.Shared; // AddNorthwindContext extension method
using System.Text.Json.Serialization; // ReferenceHandler
using System.Text.Json; // JsonSerializerOptions
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Northwind.BlazorLibraries.Client.Pages;

var builder = WebApplication.CreateBuilder(args);

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

app.MapGet("api/categories", (
  [FromServices] NorthwindContext db) =>
    Results.Json(
      db.Categories.Include(c => c.Products), 
      jsonOptions))
  .WithName("GetCategories")
  .Produces<Category[]>(StatusCodes.Status200OK);

app.MapGet("api/orders/", (
  [FromServices] NorthwindContext db) =>
    Results.Json(
      db.Orders.Include(o => o.OrderDetails),
      jsonOptions))
  .WithName("GetOrders")
  .Produces<Order[]>(StatusCodes.Status200OK);

app.MapGet("api/employees/", (
  [FromServices] NorthwindContext db) =>
    Results.Json(db.Employees, jsonOptions))
  .WithName("GetEmployees")
  .Produces<Employee[]>(StatusCodes.Status200OK);

app.MapGet("api/countries/", (
  [FromServices] NorthwindContext db) =>
    Results.Json(db.Employees.Select(emp => emp.Country).Distinct()))
  .WithName("GetCountries")
  .Produces<string[]>(StatusCodes.Status200OK);

app.MapGet("api/cities/", (
  [FromServices] NorthwindContext db) =>
    Results.Json(db.Employees.Select(emp => emp.City).Distinct()))
  .WithName("GetCities")
  .Produces<string[]>(StatusCodes.Status200OK);

app.MapPut("api/employees/{id:int}", async (
    [FromRoute] int id,
    [FromBody] Employee employee,
    [FromServices] NorthwindContext db) =>
  {
    Employee? foundEmployee = await db.Employees.FindAsync(id);

    if (foundEmployee is null) return Results.NotFound();

    foundEmployee.FirstName = employee.FirstName;
    foundEmployee.LastName = employee.LastName;
    foundEmployee.BirthDate = employee.BirthDate;
    foundEmployee.HireDate = employee.HireDate;
    foundEmployee.Address = employee.Address;
    foundEmployee.City = employee.City;
    foundEmployee.Country = employee.Country;
    foundEmployee.Region = employee.Region;
    foundEmployee.PostalCode = employee.PostalCode;
    foundEmployee.ReportsTo = employee.ReportsTo;
    foundEmployee.Title = employee.Title;
    foundEmployee.TitleOfCourtesy = employee.TitleOfCourtesy;
    foundEmployee.Notes = employee.Notes;

    int affected = await db.SaveChangesAsync();

    return Results.Json(affected);
  })
  .Produces(StatusCodes.Status200OK)
  .Produces(StatusCodes.Status404NotFound);

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
