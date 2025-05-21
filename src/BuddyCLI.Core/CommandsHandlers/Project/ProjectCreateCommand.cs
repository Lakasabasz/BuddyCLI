using BuddyCLI.Core.ArgsFacades;

namespace BuddyCLI.Core.CommandsHandlers.Project;

public class ProjectCreateCommand(ArgumentParser args) : ICommandHandler
{

    private readonly ProjectsCommandFacade _args = new ProjectsCommandFacade(args);

    public Resources Resource => Resources.Project;
    public Operations Operation => Operations.Add;
    
    public string Description => "Create new project";

    public void Handle()
    {
        throw new NotImplementedException();
    }

    public bool CanHandle() => _args is {IsProjectResource: true, Operation: Operations.Add};

    public bool Validate() => throw new NotImplementedException();
}