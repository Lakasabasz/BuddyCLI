namespace BuddyCLI.Core.Displays;

public static class DisplayManagerExtension
{
    public static IDisplayManager SendColorizedCommand(this IDisplayManager displayManager, Resources resource, Operations operation, string? @params = null)
    {
        return displayManager.AddMessage("bdyctl").SetColor(ConsoleColor.Gray).Send()
            .AddMessage(" " + resource.ToString().ToLower()).SetColor(ConsoleColor.DarkYellow).Send()
            .AddMessage(" " + operation.ToString().ToLower().FilterOutNone()).SetColor(ConsoleColor.DarkCyan).Send()
            .AddMessage((@params is not null ? " " : "") + @params).Send();
    }
}