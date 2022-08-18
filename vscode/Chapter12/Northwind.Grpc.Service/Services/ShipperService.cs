using Grpc.Core; // ServerCallContext
using Packt.Shared; // NorthwindContext
using ShipperEntity = Packt.Shared.Shipper;

namespace Northwind.Grpc.Service.Services;

public class ShipperService : Shipper.ShipperBase
{
  protected readonly ILogger<ShipperService> _logger;
  protected readonly NorthwindContext db;

  public ShipperService(ILogger<ShipperService> logger,
    NorthwindContext db)
  {
    _logger = logger;
    this.db = db;
  }

  public override async Task<ShipperReply?> GetShipper(
    ShipperRequest request, ServerCallContext context)
  {
    _logger.LogCritical(
      "This request has a deadline of {0:T}. It is now {1:T}.", 
      context.Deadline, DateTime.UtcNow);

    await Task.Delay(TimeSpan.FromSeconds(5));

    ShipperEntity? shipper = await db.Shippers.FindAsync(request.ShipperId);

    if (shipper == null)
    {
      return null;
    }
    else
    {
      return ToShipperReply(shipper);
    }
  }

  private ShipperReply ToShipperReply(ShipperEntity shipper)
  {
    return new ShipperReply
    {
      ShipperId = shipper.ShipperId,
      CompanyName = shipper.CompanyName,
      Phone = shipper.Phone
    };
  }
}
