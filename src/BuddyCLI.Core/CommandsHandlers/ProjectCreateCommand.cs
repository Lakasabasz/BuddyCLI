namespace BuddyCLI.Core.CommandsHandlers;

public class ProjectCreateCommand: ICommandHandler
{

    public Resources Resource => Resources.Project;
    public Operations Operation => Operations.Add;
    
    public string Description => "Create new project";

    public void Handle()
    {
        throw new NotImplementedException();
    }

    public bool CanHandle() => throw new NotImplementedException();

    public bool Validate() => throw new NotImplementedException();

    public void HandleValidationError()
    {
        throw new NotImplementedException();
    }
}