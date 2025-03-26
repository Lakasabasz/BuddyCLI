namespace BuddyCLI.Core;

public class DefaultResolver: IResolver
{
    private readonly ArgumentParser _args;

    public DefaultResolver(ArgumentParser args)
    {
        _args = args;

    }

    public ExitCode Handle() => throw new NotImplementedException();
}