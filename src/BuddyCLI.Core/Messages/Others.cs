namespace BuddyCLI.Core.Messages;

public static partial class LogMessages
{
    public static class Others
    {
        public static string ErrorDuringCommand(string commandError) => $"Error occurred during command: {commandError}";
        public static string Sww => $"Something went wrong";

        public static string LoadedCommands(int handlersCount) => $"Loaded {handlersCount} commands";
        public static string CommandNotFound => $"Command not found";

        public static string MissingRequiredParam(string paramName, string help) 
            => $"""
                Command required parameter {paramName} is missing. You have to provide a api server url. More info about api server url: https://buddy.works/docs/api/getting-started/overview

                {help}
                """;
        
        public static string InvalidUrl => $"Invalid URL";

        public static string NotSupportedUrlSchema(string serverScheme) => $"The server schema '{serverScheme}' is not supported. Supported schemas: http, https";

        public static string MissingRequiredArgument(string help)
            => $"""
                Command required argument is missing.

                {help}
                """;

        public static string LoginSuccess(string host) => $"Login success to {host}";
    }
}
