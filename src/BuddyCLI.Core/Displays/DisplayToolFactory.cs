namespace BuddyCLI.Core.Displays;

public class DisplayToolFactory
{
    public virtual IDisplayManager CreateDisplayManager() => new DefaultDisplayManager();
    public virtual ILogger CreateLogger(ArgumentParser parser, object scope) => new DefaultLogger(parser, scope);
}