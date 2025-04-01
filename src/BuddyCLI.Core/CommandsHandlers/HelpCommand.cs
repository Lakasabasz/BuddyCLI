using BuddyCLI.Core.ArgsFacades;

namespace BuddyCLI.Core.CommandsHandlers;

public class HelpCommand : ICommandHandler
{
    private readonly ILogger _logger;
    private readonly Lazy<IEnumerable<ICommandHandler>> _commands;
    private readonly HelpCommandFacade _args;

    public HelpCommand(ArgumentParser args, Lazy<IEnumerable<ICommandHandler>> registeredCommands)
    {
        _args = new HelpCommandFacade(args);
        _logger = new DefaultLogger(args, this);
        _commands = registeredCommands;
    }

    public Resources Resource => Resources.Help;
    public Operations Operation => Operations.None;
    public string Description => "Show help";

    private static string GetAliases(IEnumerable<string> aliases)
    {
        var list = aliases.ToList();
        return list.Any(x => !string.IsNullOrEmpty(x)) ? $"(aliases: {string.Join(", ", list)})" : string.Empty;
    }
    
    public void Handle()
    {
        var help = string.Join('\n', _commands.Value.OrderBy(x => x.Resource).ThenBy(x => x.Operation)
            .Select(x => $"{x.Resource}{GetAliases(x.Resource.GetAliases())}" +
                $"\t\t{x.Operation}{GetAliases(x.Operation != Operations.None ? [] : x.Operation.GetAliases())}" +
                $"\t\t{x.Description}"));
        _logger.Info($"""
                      List of commands:
                      {help}
                      
                      For more information use bdyctl <resource> <command> --help or bdy <resource> <command> -h"
                      """);
    }

    public bool CanHandle() => _args.IsHelpResource;

    public bool Validate() => true;

    public void HandleValidationError() => throw new InvalidOperationException("Operation does not have validation");

    public override string ToString() => nameof(HelpCommand);
}