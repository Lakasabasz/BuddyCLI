namespace BuddyCLI.Core;

public interface ICommandHandler
{
    void Handle(ArgumentParser args);
    
    bool CanHandle();
    
    bool Validate();

    void HandleValidationError();
}