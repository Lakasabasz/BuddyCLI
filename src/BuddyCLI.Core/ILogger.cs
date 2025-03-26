namespace BuddyCLI.Core;

public interface ILogger
{
    ILogger Verbose(string message);
    ILogger Debug(string message);
    ILogger Info(string message);
    ILogger Warning(string message);
    ILogger Error(string message);
    
    ILogger Fatal(string message, Exception ex);
    
    ILogger WithException(Exception ex);
}