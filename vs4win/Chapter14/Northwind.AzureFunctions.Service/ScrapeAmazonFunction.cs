using Microsoft.Azure.WebJobs; // [FunctionName], [TimerTrigger]
using Microsoft.Extensions.Logging; // ILogger
using System.IO; // Stream, StreamReader
using System.IO.Compression; // GZipStream, CompressionMode
using System.Net.Http; // IHttpClientFactory, HttpClient
using System.Threading.Tasks; // Task<T>

namespace Northwind.AzureFunctions.Service;

public class ScrapeAmazonFunction
{
  private const string relativePath = 
    "10-NET-Cross-Platform-Development-websites/dp/1801077363/";

  private readonly IHttpClientFactory clientFactory;

  public ScrapeAmazonFunction(IHttpClientFactory clientFactory)
  {
    this.clientFactory = clientFactory;
  }

  [FunctionName(nameof(ScrapeAmazonFunction))]
  public async Task Run( // every hour
    [TimerTrigger("0 0 * * * *")] TimerInfo timer,
    ILogger log)
  {
    log.LogInformation("C# Timer trigger function executed at {0}.",
      System.DateTime.UtcNow);

    log.LogInformation(
      "C# Timer trigger function next three occurrences at: " +
      $"{timer.FormatNextOccurrences(3, System.DateTime.UtcNow)}.");

    HttpClient client = clientFactory.CreateClient("Amazon");
    HttpResponseMessage response = await client.GetAsync(relativePath);
    log.LogInformation($"Request: GET {client.BaseAddress}{relativePath}");

    if (response.IsSuccessStatusCode)
    {
      log.LogInformation($"Successful HTTP request.");

      // read the content from a GZIP stream into a string
      Stream stream = await response.Content.ReadAsStreamAsync();
      GZipStream gzipStream = new(stream, CompressionMode.Decompress);
      StreamReader reader = new(gzipStream);
      string page = reader.ReadToEnd();

      // extract the Best Sellers Rank
      int posBsr = page.IndexOf("Best Sellers Rank");
      string bsrSection = page.Substring(posBsr, 45);

      // bsrSection will be something like:
      //   "Best Sellers Rank: </span> #22,258 in Books ("

      // get the position of the # and the following space
      int posHash = bsrSection.IndexOf("#") + 1;
      int posSpaceAfterHash = bsrSection.IndexOf(" ", posHash);

      // get the BSR number as text
      string bsr = bsrSection.Substring(
        posHash, posSpaceAfterHash - posHash);
      bsr = bsr.Replace(",", null); // remove commas

      // parse the text into a number
      if (int.TryParse(bsr, out int bestSellersRank))
      {
        log.LogInformation($"Best Sellers Rank #{bestSellersRank:N0}.");
      }
      else
      {
        log.LogError($"Failed to extract BSR number from: {bsrSection}.");
      }
    }
    else
    {
      log.LogError($"Bad HTTP request.");
    }
  }
}
