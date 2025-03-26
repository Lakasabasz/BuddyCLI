using BuddyCLI.Core.ArgsFacades;
using Serilog;
using Serilog.Events;

namespace BuddyCLI.Core;

public class DefaultLogger: ILogger
{
    private readonly Serilog.ILogger logger;
    private readonly string scope;
    
    public DefaultLogger(ArgumentParser args, object logScope)
    {
        var loggerArgs = new LoggerArgsFacade(args);
        LogEventLevel level = LogEventLevel.Information;
        logger = new LoggerConfiguration()
            .MinimumLevel.Is(level)
            .WriteTo.Console()
            .WriteTo.File("log.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        scope = (logScope is string s ? s : logScope.ToString())!;
    }
    
    private string FormatMessage(string message) => $"[{scope}] " + message;

    public ILogger Verbose(string message) => throw new NotImplementedException();

    public ILogger Debug(string message) => throw new NotImplementedException();

    public ILogger Info(string message) => throw new NotImplementedException();

    public ILogger Warning(string message) => throw new NotImplementedException();

    public ILogger Error(string message) => throw new NotImplementedException();

    public ILogger Fatal(string message, Exception ex) => throw new NotImplementedException();

    public ILogger WithException(Exception ex) => throw new NotImplementedException();
}