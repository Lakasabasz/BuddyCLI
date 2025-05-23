using Autofac;
using Autofac.Core;
using BuddyCLI.Core.Displays;
using BuddyCLI.Core.Messages;

namespace BuddyCLI.Core;

public class DefaultResolver: IResolver
{
    private readonly ArgumentParser _args;
    private readonly IContainer _container;
    private readonly List<ICommandHandler> _handlers;
    private readonly ILogger _logger;

    public DefaultResolver(ArgumentParser args, DisplayToolFactory displayFactory)
    {
        _logger = new DefaultLogger(args, this);
        _args = args;
        var builder = new ContainerBuilder();
        builder.RegisterAssemblyTypes(GetType().Assembly)
            .Where(x => x.GetInterface(nameof(ICommandHandler)) is not null).AsSelf()
            .AsImplementedInterfaces();
        builder.Register<ArgumentParser>(_ => args).AsSelf();
        builder.Register<DisplayToolFactory>(_ => displayFactory).AsSelf();
        _container = builder.Build();
        
        _handlers = _container.Resolve<IEnumerable<ICommandHandler>>().ToList();
        _logger.Debug(LogMessages.Others.LoadedCommands(_handlers.Count));
    }

    public ExitCode Handle()
    {
        var handler = _handlers.FirstOrDefault(x => x.CanHandle());
        if(handler is null)
        {
            if(!(string.IsNullOrWhiteSpace(_args.Resource) && string.IsNullOrWhiteSpace(_args.Command)))
                _logger.Error(LogMessages.Others.CommandNotFound);
            _handlers.First(x => x.Resource == Resources.Help).Handle();
            return ExitCode.CommandNotFound;
        }
        if(!handler.Validate()) return ExitCode.InvalidCommand;
        
        handler.Handle();
        
        return ExitCode.Success;
    }
}