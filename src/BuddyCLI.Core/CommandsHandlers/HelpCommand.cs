using BuddyCLI.Core.ArgsFacades;

namespace BuddyCLI.Core.CommandsHandlers;

public class HelpCommand : ICommandHandler
{
    private readonly ILogger _logger;
    private readonly IEnumerable<ICommandHandler> _commands;
    private readonly HelpCommandFacade _args;

    public HelpCommand(ArgumentParser args, IEnumerable<ICommandHandler> registeredCommands)
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
        var help = _commands.OrderBy(x => x.Resource).ThenBy(x => x.Operation)
            .Select(x => $"{x.Resource}({x.Resource.GetAliases().Aggregate(", ", (accumulated, current) => accumulated + current)})" +
                                        $"\t\t{x.Operation}({x.Operation.GetAliases().Aggregate(", ", (accumulated, current) => accumulated + current)})" +
                                        $"\t\t{x.Description}")
            .Aggregate(Environment.NewLine, (accumulated, current) => accumulated + current);
        _logger.Info($"""
                      List of commands:
                      {help}
                      
                      For more information use <resource> <command> --help or
                      """);
    }

    public bool CanHandle() => _args.IsHelpResource;

    public bool Validate() => true;

    public void HandleValidationError() => throw new InvalidOperationException("Operation does not have validation");
}