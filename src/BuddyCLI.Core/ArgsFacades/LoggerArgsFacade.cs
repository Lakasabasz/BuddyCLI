namespace BuddyCLI.Core.ArgsFacades;

public class LoggerArgsFacade(ArgumentParser args)
{
    public bool Verbose => args.Params.Any(x => x.Key.Contains("--verbose", StringComparison.CurrentCultureIgnoreCase));
    
    public bool Debug => args.Params.Any(x => x.Key.Contains("--debug", StringComparison.CurrentCultureIgnoreCase));
}