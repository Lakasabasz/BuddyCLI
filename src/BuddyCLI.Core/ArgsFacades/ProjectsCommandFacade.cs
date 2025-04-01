namespace BuddyCLI.Core.ArgsFacades;

public class ProjectsCommandFacade(ArgumentParser args): ResourceFacadeAbstract(args)
{
    public bool IsProjectResource => args.Resource.TryParseValueIncludingAliases(out Resources resource) && resource == Resources.Project;
    
    public Operations? Operation => args.Command.TryParseValueIncludingAliases(out Operations operation) ? operation : null;
}