namespace BuddyCLI.Core;

public static class SecretsService
{
    public static void StorePAT(string pat)
    {
        var tokenFilePath = GetTokenFilePath();
        Directory.CreateDirectory(Path.GetDirectoryName(tokenFilePath)!);
        
        // Encrypt the token before storing
        var encryptedData = EncryptToken(pat);
        File.WriteAllText(tokenFilePath, encryptedData);
    }

    public static string GetAccessToken()
    {
        var tokenFilePath = GetTokenFilePath();
        if (!File.Exists(tokenFilePath))
        {
            throw new FileNotFoundException("No token found. Please login first.");
        }
        
        var fileContent = File.ReadAllText(tokenFilePath);
        return DecryptToken(fileContent);
    }

    private static string GetTokenFilePath()
    {
        var tokenDir = Path.Combine(ConfigService.GetUserDirectory(), ConfigService.TOKEN_DIRECTORY);
        return Path.Combine(tokenDir, $"{Environment.UserName}_token.dat");
    }
    
    private static string EncryptToken(string token)
    {
        return Convert.ToBase64String(EncryptionHelper.Encrypt(token));
    }
    
    private static string DecryptToken(string encryptedToken)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedToken);
        return EncryptionHelper.Decrypt(encryptedBytes);
    }
}