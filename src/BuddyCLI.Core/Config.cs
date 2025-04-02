namespace BuddyCLI.Core;

public class Config
{
    public string Host { get; set; } = null!;

    public void Save() => ConfigService.SaveConfig(this);

    public Config WithHost(string host)
    {
        Host = host;
        return this;
    }
}