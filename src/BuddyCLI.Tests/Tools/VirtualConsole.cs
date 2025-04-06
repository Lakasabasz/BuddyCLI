namespace BuddyCLI.Tests.Tools;

public record struct MessageData(string Message, ConsoleColor Foreground);

class VirtualConsole
{
    public List<MessageData> Messages { get; } = [];
    public ConsoleColor ForegroundColor { get; set; } = ConsoleColor.White;

    
    public void WriteLine(string message="")
    {
        Messages.Add(new MessageData(message + Environment.NewLine, string.IsNullOrWhiteSpace(message) ? ConsoleColor.White : ForegroundColor));
    }
        
    public void Write(string message)
    {
        Messages.Add(new MessageData(message, string.IsNullOrWhiteSpace(message) ? ConsoleColor.White : ForegroundColor));
    }
}