namespace BuddyCLI.Core.ArgsFacades;

public class LoginCommandArgsFacade(ArgumentParser args) : ResourceFacadeAbstract(args)
{
    public bool IsLoginResource => args.Resource.TryParseValueIncludingAliases(out Resources resource) && resource == Resources.Login;
    
    public string PersonalAccessToken => args.Arguments.FirstOrDefault() ?? string.Empty;
    
    public const string HostParam = "host";
    public string Host => args.Params.FirstOrDefault(x => x.Key.ContainsParam(HostParam)).Value;
}