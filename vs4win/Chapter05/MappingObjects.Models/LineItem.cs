namespace Packt.Entities;

public record class LineItem(
  string ProductName,
  decimal UnitPrice,
  int Quantity
);
