using Autofac;
using Autofac.Core;
using BuddyCLI.Core.Messages;

namespace BuddyCLI.Core;

public class DefaultResolver: IResolver
{
    private readonly ArgumentParser _args;
    private readonly IContainer _container;
    private readonly List<ICommandHandler> _handlers;
    private readonly ILogger _logger;

    public DefaultResolver(ArgumentParser args)
    {
        _logger = new DefaultLogger(args, this);
        _args = args;
        var builder = new ContainerBuilder();
        builder.RegisterAssemblyTypes(GetType().Assembly)
            .Where(x => x.GetInterface(nameof(ICommandHandler)) is not null).AsSelf()
            .AsImplementedInterfaces();
        builder.Register<ArgumentParser>(_ => args).AsSelf();
        _container = builder.Build();
        
        _handlers = _container.Resolve<IEnumerable<ICommandHandler>>().ToList();
        _logger.Debug(LogMessages.Others.LoadedCommands(_handlers.Count));
    }

    public ExitCode Handle()
    {
        var handler = _handlers.FirstOrDefault(x => x.CanHandle());
        if(handler is null)
        {
            _logger.Error(LogMessages.Others.CommandNotFound);
            return ExitCode.CommandNotFound;
        }
        if(!handler.Validate())
        {
            handler.HandleValidationError();
            return ExitCode.InvalidCommand;
        }
        
        handler.Handle();
        
        return ExitCode.Success;
    }
}