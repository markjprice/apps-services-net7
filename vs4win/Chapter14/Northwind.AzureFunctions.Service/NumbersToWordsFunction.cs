// IActionResult, OkObjectResult, BadRequestObjectResult
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs; // [FunctionName], [HttpTrigger]
using Microsoft.Azure.WebJobs.Extensions.Http; // AuthorizationLevel
using Microsoft.AspNetCore.Http; // HttpRequest
using Microsoft.Extensions.Logging; // ILogger
using System.Numerics; // BigInteger
using Packt.Shared; // ToWords extension method
using System.Threading.Tasks; // Task<T>

namespace Northwind.AzureFunctions.Service;

[StorageAccount("AzureWebJobsStorage")]
public static class NumbersToWordsFunction
{
  [FunctionName(nameof(NumbersToWordsFunction))]
  public static async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, 
      "get", "post", Route = null)] HttpRequest req,
    [Queue("checksQueue")] ICollector<string> collector,
    ILogger log)
  {
    log.LogInformation("C# HTTP trigger function processed a request.");

    string amount = req.Query["amount"];

    if (BigInteger.TryParse(amount, out BigInteger number))
    {
      string words = number.ToWords();
      collector.Add(words);
      return await Task.FromResult(new OkObjectResult(words));
    }
    else
    {
      return new BadRequestObjectResult($"Failed to parse: {amount}");
    }
  }
}
