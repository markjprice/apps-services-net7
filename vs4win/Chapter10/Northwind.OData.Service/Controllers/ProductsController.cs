using Microsoft.AspNetCore.Mvc; // IActionResult
using Microsoft.AspNetCore.OData.Query; // [EnableQuery]
using Microsoft.AspNetCore.OData.Routing.Controllers; // ODataController
using Packt.Shared; // NorthwindContext

namespace Northwind.OData.Service.Controllers;

public class ProductsController : ODataController
{
  protected readonly NorthwindContext db;

  public ProductsController(NorthwindContext db)
  {
    this.db = db;
  }

  [EnableQuery]
  public IActionResult Get(string version = "1")
  {
    Console.WriteLine($"*** ProductsController version {version}.");
    return Ok(db.Products);
  }

  [EnableQuery]
  public IActionResult Get(int key, string version = "1")
  {
    Console.WriteLine($"*** ProductsController version {version}.");

    IQueryable<Product> products = db.Products.Where(
      product => product.ProductId == key);

    Product? p = products.FirstOrDefault();

    if ((products is null) || (p is null))
    {
      return NotFound($"Product with id {key} not found.");
    }

    if (version == "2")
    {
      p.ProductName += " version 2.0";
    }

    return Ok(p);
  }

  public IActionResult Post([FromBody] Product product)
  {
    db.Products.Add(product);
    db.SaveChanges();
    return Created(product);
  }

  public IActionResult Delete(int key)
  {
    Product? productToDelete = db.Products.Find(key);

    if(productToDelete is null)
    {
      return NotFound();
    }

    db.Products.Remove(productToDelete);
    db.SaveChanges();

    return NoContent();
  }
}
