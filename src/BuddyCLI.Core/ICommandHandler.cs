namespace BuddyCLI.Core;

public interface ICommandHandler
{
    void Handle();
    
    bool CanHandle();
    
    bool Validate();

    void HandleValidationError();
}