// [FunctionsStartup], FunctionsStartup, IFunctionsHostBuilder
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

// AddHttpClient extension method
using Microsoft.Extensions.DependencyInjection;

// MediaTypeWithQualityHeaderValue
using System.Net.Http.Headers;

[assembly: FunctionsStartup(typeof(
  Northwind.AzureFunctions.Service.AzureFunctionsStartup))]

namespace Northwind.AzureFunctions.Service;

public class AzureFunctionsStartup : FunctionsStartup
{
  public override void Configure(IFunctionsHostBuilder builder)
  {
    builder.Services.AddHttpClient(name: "Amazon", 
      configureClient: options =>
    {
      options.BaseAddress = new System.Uri("https://www.amazon.com");

      // pretend to be Chrome in US English

      options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
      options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
      options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));
      options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/avif"));
      options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/webp"));
      options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/apng"));
      options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.8));
      
      options.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-US"));
      options.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-GB",0.9));
      options.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en",0.8));

      options.DefaultRequestHeaders.UserAgent.Add(
        new(productName: "Chrome", productVersion: "102.0.0.0"));
    });
  }
}
