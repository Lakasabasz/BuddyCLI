using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace BuddyCLI.Core;

public static class ConfigService
{
    public const string TOKEN_DIRECTORY = ".bdycli";

    public static string GetUserDirectory()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        if(!Directory.Exists(path)) Directory.CreateDirectory(path);
        return path;
    }

    private static string ConfigPath => Path.Combine(GetUserDirectory(), TOKEN_DIRECTORY, "config.yml");
    
    public static void SaveConfig(Config config)
    {
        var serializer = new SerializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();
        File.WriteAllText(ConfigPath, serializer.Serialize(config));
    }
    
    public static Config Config => !File.Exists(ConfigPath) ? new Config() : new DeserializerBuilder()
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .Build()
        .Deserialize<Config>(File.ReadAllText(ConfigPath));
}