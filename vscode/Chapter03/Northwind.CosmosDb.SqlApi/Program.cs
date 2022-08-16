//await CreateCosmosResources();
await CreateProductItems();
await ListProductItems("SELECT p.id, p.productName, p.unitPrice FROM Items p WHERE p.category.categoryName = 'Beverages'");
//await DeleteProductItems();