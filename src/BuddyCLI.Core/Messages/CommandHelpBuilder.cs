namespace BuddyCLI.Core.Messages;

public class CommandHelpBuilder(Resources resource, Operations operation, string commandDescription)
{
    private readonly List<string> _params = [];
    private readonly List<string> _examples = [];

    public CommandHelpBuilder WithParam(string param, string exampleValue, string description)
    {
        _params.Add($"-{param}, --{param}={exampleValue}\t\t{description}");
        return this;
    }

    public CommandHelpBuilder WithExample(string exampleValue, string description)
    {
        _examples.Add($"- {exampleValue}\t\t{description}");
        return this;
    }

    public string Build() => 
        $"{resource} {resource.GetAliases().ToStringList()}\t\t{operation} {(operation != Operations.None ? [] : operation.GetAliases()).ToStringList()}\t\t{commandDescription}"
        + Environment.NewLine + Environment.NewLine
        + string.Join(Environment.NewLine, _params) + Environment.NewLine
        + string.Join(Environment.NewLine, _examples);
        
}