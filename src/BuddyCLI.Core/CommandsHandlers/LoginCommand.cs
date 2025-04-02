using Autofac.Core.Activators.Reflection;
using BuddyCLI.Core.ArgsFacades;
using BuddyCLI.Core.Messages;

namespace BuddyCLI.Core.CommandsHandlers;

public class LoginCommand: ICommandHandler
{
    private readonly ILogger _logger;
    private readonly LoginCommandArgsFacade _args;

    private string _help => new CommandHelpBuilder(Resource, Operation, Description)
        .WithParam(LoginCommandArgsFacade.HostParam, "api.eu.buddy.works", "Api server url")
        .WithExample("bdyctl login pat --host api.eu.buddy.works <personal token>", "This command logs in to api.eu.buddy.works realm using provided token")
        .Build();

    public LoginCommand(ArgumentParser args)
    {
        _logger = new DefaultLogger(args, this);
        _args = new LoginCommandArgsFacade(args);
    }

    public Resources Resource => Resources.Login;
    public Operations Operation => Operations.Pat;
    public string Description => "Command allow you to log in using personal access token";
    public void Handle()
    {
        if(_args.HasHelpParam)
        {
            _logger.Info(_help);
            return;
        }
        
        SecretsService.StorePAT(_args.PersonalAccessToken);
        ConfigService.Config.WithHost(_args.Host).Save();
        
        _logger.Info(LogMessages.Others.LoginSuccess(_args.Host));
    }

    public bool CanHandle() => _args is {IsLoginResource: true, Operation: Operations.Pat};

    public bool Validate()
    {
        if(_args.HasHelpParam) return true;
        if(string.IsNullOrWhiteSpace(_args.Host))
        {
            _logger.Error(LogMessages.Others.MissingRequiredParam(LoginCommandArgsFacade.HostParam, _help));
            return false;
        }
        if(string.IsNullOrWhiteSpace(_args.PersonalAccessToken))
        {
            _logger.Error(LogMessages.Others.MissingRequiredArgument(_help));
            return false;
        }
        try
        {
            Uri server = new Uri(_args.Host);
            if(server.Scheme != "http" && server.Scheme != "https")
            {
                _logger.Error(LogMessages.Others.NotSupportedUrlSchema(server.Scheme));
                return false;
            }
        }
        catch (UriFormatException)
        {
            _logger.Error(LogMessages.Others.InvalidUrl);
            return false;
        }
        return true;
    }
    
    public override string ToString() => nameof(LoginCommand);
}