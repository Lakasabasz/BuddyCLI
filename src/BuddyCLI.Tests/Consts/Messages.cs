using BuddyCLI.Tests.Tools;

namespace BuddyCLI.Tests.Consts;

static class Messages
{
    public static MessageData Header => new MessageData("bdyctl 1.0.0.0v - Community command line interface client to buddy.works", ConsoleColor.White);
    
    public static MessageData Usage => new MessageData("USAGE", ConsoleColor.White);
        
    public static MessageData[] HelpUsage => [Padding.Padding1, Usage];
}