namespace BuddyCLI.Core;

public enum Resources
{
    [Alias("ws")] Workspace,
    [Alias("proj")] Project,
    Pipeline,
    [Alias("env")] Environment,
    Action,
    [Alias("var")] Variable,
    [Alias("execution")][Alias("exec")] Run,
    [Alias("?")] Help,
    Login
}