using Northwind.GraphQL; // Query
using Packt.Shared; // AddNorthwindContext extension method

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNorthwindContext();

builder.Services
  .AddGraphQLServer()
  .RegisterDbContext<NorthwindContext>()
  .AddQueryType<Query>()
  .AddMutationType<Mutation>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL();

app.Run();
