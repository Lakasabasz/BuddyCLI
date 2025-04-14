using BuddyCLI.Tests.Tools;

namespace BuddyCLI.Tests.Consts;

static class Messages
{
    public static MessageData Header => new MessageData("bdycli 1.0.0.0v - Community command line interface client to buddy.works", ConsoleColor.White);
    
    public static MessageData Usage => new MessageData("USAGE", ConsoleColor.White);
    public static MessageData Commands => new MessageData("COMMANDS", ConsoleColor.White);
        
    public static MessageData[] HelpUsage => [Padding.Padding1, Usage, Padding.NewLine];
    public static MessageData[] HelpCommands => [Padding.Padding1, Commands, Padding.NewLine];
    
    public static MessageData BdyCli => new MessageData("bdycli", ConsoleColor.Gray);
    public static MessageData BdyCliTab1WithTailingSpace => new MessageData("\tbdycli ", ConsoleColor.Gray);
    
    public static MessageData ResourceWithTailingSpace => new MessageData("<RESOURCE> ", ConsoleColor.DarkYellow);
    public static MessageData OperationWithTailingSpace => new MessageData("<OPERATION> ", ConsoleColor.DarkCyan);
    public static MessageData ParamsAndArgs => new MessageData("[PARAMS] [-h|--help] [ARGUMENTS]", ConsoleColor.White);
    
    public static MessageData[] GeneralUsageCommand => [BdyCliTab1WithTailingSpace, ResourceWithTailingSpace, OperationWithTailingSpace, ParamsAndArgs, Padding.NewLine];
    
    public static MessageData PaddedResource(string cmd, int padding) => new MessageData(cmd.PadRight(padding, ' '), ConsoleColor.DarkYellow);

    public static MessageData PaddedAliases(string[] aliases, int padding)
        => new MessageData($"(aliases: {string.Join(", ", aliases)})".PadRight(padding, ' '), ConsoleColor.Gray);
}