using Packt.Shared;

namespace Northwind.Common.EntityModels.Tests
{
  public class NorthwindEntityModelsTests
  {
    [Fact]
    public void CanConnectIsTrue()
    {
      using (NorthwindContext db = new()) // arrange
      {
        bool canConnect = db.Database.CanConnect(); // act

        Assert.True(canConnect); // assert
      }
    }

    [Fact]
    public void ProviderIsSqlServer()
    {
      using (NorthwindContext db = new())
      {
        string? provider = db.Database.ProviderName;

        Assert.Equal("Microsoft.EntityFrameworkCore.SqlServer", provider);
      }
    }

    [Fact]
    public void ProductId1IsChai()
    {
      using(NorthwindContext db = new())
      {
        Product product1 = db.Products.Single(p => p.ProductId == 1);

        Assert.Equal("Chai", product1.ProductName);
      }
    }
  }
}