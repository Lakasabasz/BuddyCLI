using BuddyCLI.Core;
using BuddyCLI.Core.ArgsFacades;
using BuddyCLI.Core.Displays;
using Serilog.Events;

namespace BuddyCLI.Tests.Tools;

class TestLogger: ILogger
{
    private readonly string scope;
    private readonly LogEventLevel level;
    private readonly VirtualConsole _vconsole;
    
    public TestLogger(ArgumentParser args, object logScope, VirtualConsole console)
    {
        var loggerArgs = new LoggerArgsFacade(args);
        LogEventLevel level = LogEventLevel.Information;
        if(loggerArgs.Debug) level = LogEventLevel.Debug;
        else if(loggerArgs.Verbose) level = LogEventLevel.Verbose;
        
        scope = (logScope is string s ? s : logScope.ToString())!;
        _vconsole = console;
    }
    
    private string FormatMessage(string message) => $"[{scope}] " + message;
    
    public ILogger Verbose(string message)
    {
        if(level > LogEventLevel.Verbose) return this;
        _vconsole.WriteLine(FormatMessage(message));
        return this;
    }
    
    public ILogger Debug(string message)
    {
        if(level > LogEventLevel.Debug) return this;
        _vconsole.WriteLine(FormatMessage(message));
        return this;
    }
    
    public ILogger Info(string message)
    {
        if(level > LogEventLevel.Information) return this;
        _vconsole.WriteLine(FormatMessage(message));
        return this;
    }
    
    public ILogger Warning(string message)
    {
        if(level > LogEventLevel.Warning) return this;
        _vconsole.WriteLine(FormatMessage(message));
        return this;
    }

    public ILogger Error(string message)
    {
        if(level > LogEventLevel.Error) return this;
        _vconsole.WriteLine(FormatMessage(message));
        return this;
    }

    public ILogger Fatal(string message, Exception ex)
    {
        if(level > LogEventLevel.Error) return this;
        _vconsole.WriteLine(FormatMessage(message));
        _vconsole.WriteLine(ex.ToString());
        return this;;
    }

    public ILogger WithException(Exception ex)
    {
        _vconsole.WriteLine(ex.Message);
        return this;
    }
}