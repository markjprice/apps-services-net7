using Gremlin.Net.Driver;
using Gremlin.Net.Driver.Exceptions;
using Gremlin.Net.Structure.IO.GraphSON;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

try
{
  if (args.Length != 1)
  {
    WriteLine("Please enter a Gremlin/Graph Query.");
  }
  else
  {
    ConfigurationBuilder azureConfig = new();

    IConfigurationSection config = azureConfig
      .SetBasePath(Environment.CurrentDirectory)
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
       .Build()
       .GetSection("AzureConfig");

    string? hostname = config["HostName"];
    int port = Convert.ToInt32(config["Port"]);
    string? authKey = config["AuthKey"];
    string? database = config["Database"];
    string? collection = config["Collection"];

    GremlinServer gremlinServer = new(
       hostname, port, enableSsl: true,
       username: $"/dbs/" + database + "/colls/" + collection,
       password: authKey);

    using (GremlinClient gremlinClient = new (
      gremlinServer, 
      new GraphSON2Reader(), 
      new GraphSON2Writer(), 
      GremlinClient.GraphSON2MimeType))
    {
      Task<ResultSet<dynamic>> resultSet = AzureAsync(gremlinClient, args[0]);

      WriteLine("\n{{\"Returned\": \"{0}\"}}", resultSet.Result.Count);

      foreach (dynamic result in resultSet.Result)
      {
        string jsonOutput = JsonConvert.SerializeObject(result);
        WriteLine(jsonOutput);
      }
    }
  }
}
catch (Exception ex)
{
  WriteLine("EXCEPTION: {0}", ex.Message);
}

static Task<ResultSet<dynamic>> AzureAsync(GremlinClient gremlinClient, string query)
{
  try
  {
    return gremlinClient.SubmitAsync<dynamic>(query);
  }
  catch (ResponseException ex)
  {
    WriteLine("EXCEPTION: {0}", ex.StatusCode);
    throw;
  }
}