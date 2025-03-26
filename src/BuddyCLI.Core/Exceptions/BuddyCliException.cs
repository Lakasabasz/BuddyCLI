namespace BuddyCLI.Core.Exceptions;

public class BuddyCliException(string simplifiedMessage): Exception
{
    public string SimplifiedMessage { get; } = simplifiedMessage;
}