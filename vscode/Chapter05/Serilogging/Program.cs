using Serilog; // Log, LoggerConfiguration, RollingInterval
using Serilog.Core; // Logger
using Serilogging.Models; // ProductPageView

using Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Logger = log;
Log.Information("The global logger has been configured");

Log.Warning("Danger, Serilog, danger!");
Log.Error("This is an error!");
Log.Fatal("Fatal problem!");

ProductPageView pageView = new() { 
  PageTitle = "Chai", 
  SiteSection = "Beverages", 
  ProductId = 1 };

Log.Information("{@PageView} occurred at {Viewed}",
  pageView, DateTimeOffset.UtcNow);

// just before ending an application
Log.CloseAndFlush();
