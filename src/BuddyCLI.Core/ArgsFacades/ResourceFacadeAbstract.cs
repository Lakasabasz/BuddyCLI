namespace BuddyCLI.Core.ArgsFacades;

public abstract class ResourceFacadeAbstract(ArgumentParser args)
{
    protected readonly ArgumentParser args = args;
    
    public bool HasHelpParam => args.Params.Any(x => x.Key is "-h" or "--help");
}