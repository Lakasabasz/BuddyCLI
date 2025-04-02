namespace BuddyCLI.Core.ArgsFacades;

public abstract class ResourceFacadeAbstract(ArgumentParser args)
{
    protected readonly ArgumentParser args = args;
    
    public bool HasHelpParam => args.Params.Any(x => x.Key is "-h" or "--help");
    
    public Operations? Operation => args.Command.TryParseValueIncludingAliases(out Operations operation) ? operation : null;
}