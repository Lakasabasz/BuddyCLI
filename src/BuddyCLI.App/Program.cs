namespace BuddyCLI.App;

public enum ExitCode
{
    Success = 0,
}

class App(string[] args)
{
    private ExitCode Process()
    {
        return ExitCode.Success;
    }
    
    static int Main(string[] args)
    {
        var app = new App(args);
        return (int)app.Process();
    }
}