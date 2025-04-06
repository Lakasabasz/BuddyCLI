using BuddyCLI.Tests.Tools;

namespace BuddyCLI.Tests.Consts;

static class Padding
{
    public static MessageData NewLine => new MessageData(Environment.NewLine, ConsoleColor.White);
    
    public static MessageData Padding1 => new MessageData("    ", ConsoleColor.White);
}