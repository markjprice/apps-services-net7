namespace FluentValidation.Models;

public class Order
{
  public long OrderId { get; set; }
  public string CustomerName { get; set; } = null!;
  public string CustomerEmail { get; set; } = null!;
  public CustomerLevel CustomerLevel { get; set; }
  public decimal Total { get; set; }
  public DateTime OrderDate { get; set; }
  public DateTime ShipDate { get; set; }
}
