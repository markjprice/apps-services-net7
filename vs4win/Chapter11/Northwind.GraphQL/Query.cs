using Microsoft.EntityFrameworkCore; // Include extension method
using Packt.Shared; // NorthwindContext

namespace Northwind.GraphQL;

public class Query
{
  public string GetGreeting() => "Hello, World!";
  public string Farewell() => "Ciao! Ciao!";
  public int RollTheDie() => Random.Shared.Next(1, 7);

  public IQueryable<Category> GetCategories(NorthwindContext db) =>
    db.Categories.Include(c => c.Products);

  public Category? GetCategory(NorthwindContext db, int categoryId)
  {
    Category? category = db.Categories.Find(categoryId);
    if (category == null) return null;
    db.Entry(category).Collection(c => c.Products).Load();
    return category;
  }

  public IQueryable<Product> GetProducts(NorthwindContext db) =>
    db.Products.Include(p => p.Category);

  public IQueryable<Product> GetProductsInCategory(
    NorthwindContext db, int categoryId) =>
      db.Products.Where(p => p.CategoryId == categoryId);
}
