using Microsoft.Data.SqlClient; // SqlConnection and so on
using System.Data; // CommandType

string server =
  // "."; // SQL Server for Windows
  // @".\net7book"; // SQL Server for Windows
  // "tcp:apps-services-net7.database.windows.net,1433"; // Azure SQL Database
  "tcp:127.0.0.1,1433"; // Azure SQL Edge

string username = "sa"; // SQL Edge
// string username = "markjprice"; // change to your username

Write("Enter your SQL Server password: ");
string? password = ReadLine();
if (password == null)
{
  WriteLine("Password cannot be empty or null!");
  return;
}

string connectionString =
  $"Server={server};" +
  "Initial Catalog=Northwind;" +
  "Persist Security Info=False;" +
  $"User ID={username};" +
  $"Password={password};" +
  "MultipleActiveResultSets=False;" +
  "Encrypt=True;" +
  "TrustServerCertificate=True;" +
  "Connection Timeout=30;";

SqlConnection connection = new(connectionString);

connection.StateChange += Connection_StateChange;
connection.InfoMessage += Connection_InfoMessage;

try
{
  // connection.Open();
  await connection.OpenAsync();

  WriteLine($"SQL Server version: {connection.ServerVersion}");
}
catch (SqlException ex)
{
  WriteLine($"SQL exception: {ex.Message}");
  return;
}

Write("Enter a unit price: ");
string? priceText = ReadLine();

if(!decimal.TryParse(priceText, out decimal price))
{
  WriteLine("You must enter a valid unit price.");
  return;
}

SqlCommand cmd = connection.CreateCommand();

/*
cmd.CommandType = CommandType.Text;
cmd.CommandText = "SELECT ProductId, ProductName, UnitPrice FROM Products"
    + " WHERE UnitPrice > @price";
cmd.Parameters.AddWithValue("price", price);
*/

cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "GetExpensiveProducts";

SqlParameter p1 = new()
{
  ParameterName = "price",
  SqlDbType = SqlDbType.Money,
  SqlValue = price
};

SqlParameter p2 = new()
{
  Direction = ParameterDirection.Output,
  ParameterName = "count",
  SqlDbType = SqlDbType.Int
};

SqlParameter p3 = new()
{
  Direction= ParameterDirection.ReturnValue,
  ParameterName = "rv",
  SqlDbType = SqlDbType.Int
};

cmd.Parameters.Add(p1);
cmd.Parameters.Add(p2);
cmd.Parameters.Add(p3);

SqlDataReader r = await cmd.ExecuteReaderAsync();

WriteLine("----------------------------------------------------------");
WriteLine("| {0,5} | {1,-35} | {2,8} |", "Id", "Name", "Price");
WriteLine("----------------------------------------------------------");

while (await r.ReadAsync())
{
  WriteLine("| {0,5} | {1,-35} | {2,8:C} |",
    await r.GetFieldValueAsync<int>("ProductId"),
    await r.GetFieldValueAsync<string>("ProductName"),
    await r.GetFieldValueAsync<decimal>("UnitPrice"));
}

WriteLine("----------------------------------------------------------");

await r.CloseAsync();

WriteLine($"Output count: {p2.Value}");
WriteLine($"Return value: {p3.Value}");

await connection.CloseAsync();
