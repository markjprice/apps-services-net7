using Microsoft.AspNetCore.Mvc; // IActionResult
using Microsoft.AspNetCore.OData.Query; // [EnableQuery]
using Microsoft.AspNetCore.OData.Routing.Controllers; // ODataController
using Packt.Shared; // NorthwindContext

namespace Northwind.OData.Service.Controllers;

public class CustomersController : ODataController
{
  protected readonly NorthwindContext db;

  public CustomersController(NorthwindContext db)
  {
    this.db = db;
  }

  [EnableQuery]
  public IActionResult Get()
  {
    return Ok(db.Customers);
  }

  [EnableQuery]
  public IActionResult Get(string key)
  {
    return Ok(db.Customers.Where(
      customer => customer.CustomerId == key));
  }
}
