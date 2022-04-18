using Serilog; // Log, LoggerConfiguration, RollingInterval
using Serilog.Core; // Logger

using Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Logger = log;
Log.Information("The global logger has been configured");

Log.Warning("Danger, Serilog, danger!");
Log.Error("This is an error!");
Log.Fatal("Fatal problem!");

// just before ending an application
Log.CloseAndFlush();
