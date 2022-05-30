using Packt.Shared; // Category

namespace Northwind.Mvc.GraphQLClient.Models;

public class ResponseCategories
{
  public class DataCategories
  {
    public Category[]? Categories { get; set; }
  }

  public DataCategories? Data { get; set; }
}
