using Packt.Shared; // Product
using System.Net.Http.Json; // ReadFromJsonAsync<T>

Write("Enter a client name: ");
string? clientName = ReadLine();

if (string.IsNullOrEmpty(clientName))
{
  clientName = $"console-client-{Guid.NewGuid()}";
}

WriteLine($"X-Client-Id will be: {clientName}");

HttpClient client = new();

client.BaseAddress = new("https://localhost:5091");

client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new("application/json"));

// specify rate limiting client id
client.DefaultRequestHeaders.Add("X-Client-Id", clientName);

ConsoleColor previousColor;

while (true)
{
  previousColor = ForegroundColor;
  ForegroundColor = ConsoleColor.DarkGreen;
  Write("{0:hh:mm:ss}: ", DateTime.UtcNow);
  ForegroundColor = previousColor;

  int waitFor = 1; // seconds

  try
  {
    HttpResponseMessage response = await client.GetAsync("api/products");

    if (response.IsSuccessStatusCode)
    {
      Product[]? products = await response.Content.ReadFromJsonAsync<Product[]>();

      if (products != null)
      {
        foreach (Product product in products)
        {
          Write(product.ProductName);
          Write(", ");
        }
        WriteLine();
      }
    }
    else
    {
      previousColor = ForegroundColor;
      ForegroundColor = ConsoleColor.DarkRed;
      WriteLine($"{(int)response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
      
      string retryAfter = response.Headers
        .GetValues("Retry-After").ToArray()[0];

      if (int.TryParse(retryAfter, out waitFor))
      {
        WriteLine($"Retry after {waitFor} seconds.");
      }
      ForegroundColor = previousColor;
    }
  }
  catch (Exception ex)
  {
    WriteLine(ex.Message);
  }

  await Task.Delay(TimeSpan.FromSeconds(waitFor));
}