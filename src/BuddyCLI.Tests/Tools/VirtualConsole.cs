namespace BuddyCLI.Tests.Tools;

public record struct MessageData(string Message, ConsoleColor Foreground);

class VirtualConsole
{
    public List<MessageData> Messages { get; } = [];
    public ConsoleColor ForegroundColor { get; set; } = ConsoleColor.White;

    
    public void WriteLine(string message="")
    {
        Messages.Add(new MessageData(message + Environment.NewLine, ForegroundColor));
    }
        
    public void Write(string message)
    {
        Messages.Add(new MessageData(message, ForegroundColor));
    }
}