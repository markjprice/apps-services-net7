using FluentValidation.Models; // Order
using FluentValidation.Results; // ValidationResult
using FluentValidation.Validators; // OrderValidator

Order order = new()
{
  OrderId = 10001,
  CustomerName = "Abcdef",
  CustomerEmail = "abc@example.com",
  CustomerLevel = CustomerLevel.Gold,
  OrderDate = new(2022, 12, 1),
  ShipDate = new(2022, 12, 5),
  Total = 49.99M
};

OrderValidator validator = new();

ValidationResult result = validator.Validate(order);

WriteLine($"CustomerName:  {order.CustomerName}");
WriteLine($"CustomerEmail: {order.CustomerEmail}");
WriteLine($"CustomerLevel: {order.CustomerLevel}");
WriteLine($"OrderId:       {order.OrderId}");
WriteLine($"OrderDate:     {order.OrderDate}");
WriteLine($"ShipDate:      {order.ShipDate}");
WriteLine($"Total:         {order.Total}");
WriteLine();
WriteLine($"IsValid:  {result.IsValid}");
foreach (var item in result.Errors)
{
  WriteLine($"  {item.Severity}: {item.ErrorMessage}");
}
