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
    
    public void Handle()
    {
        var help = string.Join('\n', _commands.Value.OrderBy(x => x.Resource).ThenBy(x => x.Operation)
            .Select(x => $"{x.Resource} {x.Resource.GetAliases().ToStringList()}" +
                $"\t\t{x.Operation} {(x.Operation != Operations.None ? [] : x.Operation.GetAliases()).ToStringList()}" +
                $"\t\t{x.Description}"));
        _logger.Info($"""
                      List of commands:
                      {help}
                      
                      For more information use bdyctl <resource> <command> --help or bdy <resource> <command> -h"
                      """);
    }

    public bool CanHandle() => _args.IsHelpResource;

    public bool Validate() => true;

    public override string ToString() => nameof(HelpCommand);
}