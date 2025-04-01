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
        if(loggerArgs.Debug) level = LogEventLevel.Debug;
        else if(loggerArgs.Verbose) level = LogEventLevel.Verbose;
        logger = new LoggerConfiguration()
            .MinimumLevel.Is(level)
            .WriteTo.Console()
            .WriteTo.File("log.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        scope = (logScope is string s ? s : logScope.ToString())!;
    }
    
    private string FormatMessage(string message) => $"[{scope}] " + message;

    public ILogger Verbose(string message) => throw new NotImplementedException();

    public ILogger Debug(string message)
    {
        logger.Debug(FormatMessage(message));
        return this;
    }

    public ILogger Info(string message)
    {
        logger.Information(FormatMessage(message));
        return this;
    }

    public ILogger Warning(string message)
    {
        logger.Warning(FormatMessage(message));
        return this;
    }

    public ILogger Error(string message)
    {
        logger.Error(FormatMessage(message));
        return this;
    }

    public ILogger Fatal(string message, Exception ex)
    {
        logger.Fatal(FormatMessage(message), ex);
        return this;
    }

    public ILogger WithException(Exception ex)
    {
        logger.Fatal(FormatMessage(ex.Message), ex);
        return this;
    }
}