using System.Reflection;
using BuddyCLI.Core.ArgsFacades;
using BuddyCLI.Core.Displays;

namespace BuddyCLI.Core.CommandsHandlers;

public class HelpCommand : ICommandHandler
{
    private readonly ILogger _logger;
    private readonly IDisplayManager _displayManager;
    private readonly Lazy<IEnumerable<ICommandHandler>> _commands;
    private readonly HelpCommandFacade _args;

    public HelpCommand(ArgumentParser args, Lazy<IEnumerable<ICommandHandler>> registeredCommands, DisplayToolFactory toolFactory)
    {
        _args = new HelpCommandFacade(args);
        _logger = toolFactory.CreateLogger(args, this);
        _displayManager = toolFactory.CreateDisplayManager();
        _commands = registeredCommands;
    }

    public Resources Resource => Resources.Help;
    public Operations Operation => Operations.None;
    public string Description => "Show help";
    
    public void Handle()
    {
        _displayManager.AddMessage($"bdyctl {Assembly.GetExecutingAssembly().GetName().Version}v - Community command line interface client to buddy.works")
            .Send().SendNewLine().SendNewLine();
        _displayManager.PadLeft(4).Send()
            .AddMessage("USAGE").Send().SendNewLine();
        _displayManager.AddMessage("\tbdyctl ").SetColor(ConsoleColor.Gray).Send()
            .AddMessage("<RESOURCE> ").SetColor(ConsoleColor.DarkYellow).Send()
            .AddMessage("<OPERATION> ").SetColor(ConsoleColor.DarkCyan).Send()
            .AddMessage("[PARAMS] [-h|--help] [ARGUMENTS]").Send().SendNewLine().SendNewLine();
        _displayManager.PadLeft(4).Send()
            .AddMessage("COMMANDS").Send().SendNewLine();
        foreach (var (key, values) in _commands.Value.GroupBy(x => x.Resource, (key, values) => (key, values)))
        {
            var resource = key;
            var commands = values.ToList();
            var firstCommand = commands.First();
            _displayManager.PadLeft(8).Send()
                .AddMessage(resource.ToString().ToLower() + " ").SetColor(ConsoleColor.DarkYellow).PadRight(10).Send()
                .AddMessage(resource.GetAliases().ToStringList()).SetColor(ConsoleColor.Gray).PadRight(16).Send()
                .AddMessage(firstCommand.Operation.ToString().FilterOutNone().ToLower() + " ").SetColor(ConsoleColor.DarkCyan).PadRight(10).Send()
                .AddMessage(firstCommand.Operation.GetAliases().ToStringList()).SetColor(ConsoleColor.Gray).PadRight(16).Send()
                .AddMessage(firstCommand.Description).Send().SendNewLine();
            foreach (var command in commands.Skip(1))
            {
                _displayManager.PadLeft(30).Send()
                    .AddMessage(command.Operation.ToString().FilterOutNone().ToLower() + " ").SetColor(ConsoleColor.DarkCyan).PadRight(10).Send()
                    .AddMessage(command.Operation.GetAliases().ToStringList()).SetColor(ConsoleColor.Gray).PadRight(16).Send()
                    .AddMessage(command.Description).Send().SendNewLine();
            }
        }
        _displayManager.SendNewLine()
            .PadLeft(4).Send().AddMessage("EXAMPLES").Send().SendNewLine();
        _displayManager.PadLeft(8).Send()
            .SendColorizedCommand(Resources.Login, Operations.Pat, $"--host api.buddy.works {Guid.Empty}").SendNewLine();
        _displayManager.PadLeft(8).Send()
            .SendColorizedCommand(Resources.Help, Operations.None).SendNewLine();
        
        _displayManager.SendNewLine()
            .AddMessage("For more information use bdyctl <resource> <command> --help or bdyctl <resource> <command> -h").Send().SendNewLine();
    }

    public bool CanHandle() => _args.IsHelpResource;

    public bool Validate() => true;

    public override string ToString() => nameof(HelpCommand);
}