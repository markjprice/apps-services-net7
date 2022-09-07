using GeneratingPdf.Document; // CatalogDocument
using GeneratingPdf.Models; // Catalog, Category
using QuestPDF.Fluent; // GeneratePdf extension method

string filename = "catalog.pdf";

Catalog model = new()
{
  Categories = new()
  {
    new() { CategoryId = 1, CategoryName = "Beverages"},
    new() { CategoryId = 2, CategoryName = "Condiments"},
    new() { CategoryId = 3, CategoryName = "Confections"},
    new() { CategoryId = 4, CategoryName = "Dairy Products"},
    new() { CategoryId = 5, CategoryName = "Grains/Cereals"},
    new() { CategoryId = 6, CategoryName = "Meat/Poultry"},
    new() { CategoryId = 7, CategoryName = "Produce"},
    new() { CategoryId = 8, CategoryName = "Seafood"},
  }
};

CatalogDocument document = new(model);
document.GeneratePdf(filename);

WriteLine($"PDF catalog has been created: {filename}");

try
{
  if (OperatingSystem.IsWindows())
  {
    System.Diagnostics.Process.Start("explorer.exe", filename);
  }
  else if (OperatingSystem.IsMacOS())
  {
    System.Diagnostics.Process.Start(
      "/Applications/TextEdit.app/Contents/MacOS/TextEdit", filename);
  }
  else
  {
    WriteLine("Open the following file manually.");
  }
}
catch (Exception ex)
{
  WriteLine($"{ex.GetType()} says {ex.Message}");
}
