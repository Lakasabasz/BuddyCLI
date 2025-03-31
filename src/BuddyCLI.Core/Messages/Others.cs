namespace BuddyCLI.Core.Messages;

public static partial class LogMessages
{
    public static class Others
    {
        public static string ErrorDuringCommand(string commandError) => $"Error occurred during command: {commandError}";
        public static string Sww => $"Something went wrong";

        public static string LoadedCommands(int handlersCount) => $"Loaded {handlersCount} commands";
        public static string CommandNotFound => $"Command not found";
    }
}
