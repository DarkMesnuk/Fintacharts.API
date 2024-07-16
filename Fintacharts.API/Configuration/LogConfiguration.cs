using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using ILogger=Serilog.ILogger;

namespace Fintacharts.API.Configuration;

public static class LogConfiguration
{
    public static IHostBuilder ConfigureLogger(this ConfigureHostBuilder host)
    {
        return host
            .ConfigureLogging(logBuilder => logBuilder.AddSerilog(ConfigureSerilogLogger()));;
    }
    
    public static ILogger ConfigureSerilogLogger() => new LoggerConfiguration()
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .MinimumLevel.Override("System", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate)
        .CreateLogger();
}