using BuddyCLI.Core.ArgsFacades;

namespace BuddyCLI.Core.CommandsHandlers.Project;

public class ProjectListCommand(ArgumentParser args): ICommandHandler
{
    
    private readonly ProjectsCommandFacade _args = new ProjectsCommandFacade(args);
    
    public Resources Resource => Resources.Project;
    public Operations Operation => Operations.List;
    public string Description => "Lists all projects in the current repository";
    public void Handle()
    {
        throw new NotImplementedException();
    }

    public bool CanHandle() => throw new NotImplementedException();

    public bool Validate() => throw new NotImplementedException();
}