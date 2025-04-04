using BuddyCLI.Core;
using BuddyCLI.Core.Displays;
using BuddyCLI.Core.Exceptions;
using BuddyCLI.Core.Messages;

namespace BuddyCLI.App;

class App
{
    private readonly ILogger logger;
    private readonly IResolver resolver;
    
    public App(ArgumentParser args, DisplayToolFactory? displayFactory = null)
    {
        displayFactory ??= new DisplayToolFactory();
        logger = displayFactory.CreateLogger(args, typeof(App));
        resolver = new DefaultResolver(args, displayFactory);
    }
    
    public ExitCode Process()
    {
        try
        {
            return resolver.Handle();
        }
        catch (BuddyCliException bdyCliEx)
        {
            logger.Error(LogMessages.Others.ErrorDuringCommand(bdyCliEx.SimplifiedMessage)).WithException(bdyCliEx);
        }
        catch (Exception ex)
        {
            logger.Fatal(LogMessages.Others.Sww, ex);
        }
        return ExitCode.Success;
    }
    
    static int Main(string[] args)
    {
        var app = new App(new ArgumentParser(args));
        return (int)app.Process();
    }
}