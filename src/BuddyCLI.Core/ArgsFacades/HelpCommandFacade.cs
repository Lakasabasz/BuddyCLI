namespace BuddyCLI.Core.ArgsFacades;

public class HelpCommandFacade(ArgumentParser args) : ResourceFacadeAbstract(args)
{
    public bool IsHelpResource => args.Resource.TryParseValueIncludingAliases(out Resources resource) && resource == Resources.Help;
}