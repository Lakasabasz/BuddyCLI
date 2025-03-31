namespace BuddyCLI.Core;

public interface ICommandHandler
{
    public Resources Resource { get; }
    public Operations Operation { get; }
    public string Description { get; }
    
    
    void Handle();
    
    bool CanHandle();
    
    bool Validate();

    void HandleValidationError();
}