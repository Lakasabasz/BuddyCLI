namespace BuddyCLI.Core.ArgsFacades;

public class LoggerArgsFacade(ArgumentParser args)
{
    public bool Verbose => args.Arguments.Any(x => x.Key.Contains("--verbose", StringComparison.CurrentCultureIgnoreCase));
    
    public bool Debug => args.Arguments.Any(x => x.Key.Contains("--debug", StringComparison.CurrentCultureIgnoreCase));
}