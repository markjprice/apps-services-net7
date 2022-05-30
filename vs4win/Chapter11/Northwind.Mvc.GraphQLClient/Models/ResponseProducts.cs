using Packt.Shared; // Product

namespace Northwind.Mvc.GraphQLClient.Models;

public class ResponseProducts
{
  public class DataProducts
  {
    public Product[]? ProductsInCategory { get; set; }
  }

  public DataProducts? Data { get; set; }
}
