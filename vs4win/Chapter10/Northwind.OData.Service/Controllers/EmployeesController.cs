using Microsoft.AspNetCore.Mvc; // IActionResult
using Microsoft.AspNetCore.OData.Query; // [EnableQuery]
using Microsoft.AspNetCore.OData.Routing.Controllers; // ODataController
using Packt.Shared; // NorthwindContext

namespace Northwind.OData.Service.Controllers;

public class EmployeesController : ODataController
{
  protected readonly NorthwindContext db;

  public EmployeesController(NorthwindContext db)
  {
    this.db = db;
  }

  [EnableQuery]
  public IActionResult Get()
  {
    return Ok(db.Employees);
  }

  [EnableQuery]
  public IActionResult Get(int key)
  {
    return Ok(db.Employees.Where(
      employee => employee.EmployeeId == key));
  }
}
