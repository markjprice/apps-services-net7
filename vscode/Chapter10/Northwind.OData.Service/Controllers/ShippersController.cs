using Microsoft.AspNetCore.Mvc; // IActionResult
using Microsoft.AspNetCore.OData.Query; // [EnableQuery]
using Microsoft.AspNetCore.OData.Routing.Controllers; // ODataController
using Packt.Shared; // NorthwindContext

namespace Northwind.OData.Service.Controllers;

public class ShippersController : ODataController
{
  protected readonly NorthwindContext db;

  public ShippersController(NorthwindContext db)
  {
    this.db = db;
  }

  [EnableQuery]
  public IActionResult Get()
  {
    return Ok(db.Shippers);
  }

  [EnableQuery]
  public IActionResult Get(int key)
  {
    return Ok(db.Shippers.Where(
      shipper => shipper.ShipperId == key));
  }
}
