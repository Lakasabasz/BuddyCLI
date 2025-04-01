using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace BuddyCLI.Core;

public class SecretService
{
    private const string TOKEN_DIRECTORY = ".toolsh";
    
    public static void StorePAT(string pat)
    {
        try
        {
            var tokenFilePath = GetTokenFilePath();
            Directory.CreateDirectory(Path.GetDirectoryName(tokenFilePath)!);
            
            // Encrypt the token before storing
            var encryptedData = EncryptToken(pat);
            File.WriteAllText(tokenFilePath, encryptedData);
            
            Console.WriteLine("Successfully logged in. Token securely stored.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error storing token: {ex.Message}");
        }
    }

    public static string GetAccessToken() => DecryptToken();
    
    private static string GetTokenFilePath()
    {
        // Get current username in a cross-platform way
        string currentUser = Environment.UserName;
        
        // Get home directory in a cross-platform way
        string userHomeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        var tokenDir = Path.Combine(userHomeDir, TOKEN_DIRECTORY);
        return Path.Combine(tokenDir, $"{currentUser}_token.dat");
    }
    
    private static string EncryptToken(string token)
    {
        // Generate a secure key and IV based on the machine and user
        // This means the encryption is tied to both the machine and user
        using var deriveBytes = new Rfc2898DeriveBytes(GetMachineKey() + Environment.UserName, GetSalt(), 10000, HashAlgorithmName.SHA512);
        byte[] key = deriveBytes.GetBytes(32); // 256 bits for AES-256
        byte[] iv = deriveBytes.GetBytes(16);  // 128 bits for IV

        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        using var sw = new StreamWriter(cs);
        sw.Write(token);

        return Convert.ToBase64String(ms.ToArray());
    }
    
    private static string DecryptToken()
    {
        var tokenFilePath = GetTokenFilePath();
        if (!File.Exists(tokenFilePath))
        {
            throw new FileNotFoundException("No token found. Please login first.");
        }
        
        string encryptedToken = File.ReadAllText(tokenFilePath);
        byte[] encryptedBytes = Convert.FromBase64String(encryptedToken);
        
        // Generate the same key and IV using the machine key and username
        using var deriveBytes = new Rfc2898DeriveBytes(GetMachineKey() + Environment.UserName, GetSalt(), 10000, HashAlgorithmName.SHA512);
        byte[] key = deriveBytes.GetBytes(32);
        byte[] iv = deriveBytes.GetBytes(16);

        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream(encryptedBytes);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        return sr.ReadToEnd();
    }
    
    // Gets a unique identifier for the machine
    private static string GetMachineKey()
    {
        try
        {
            // On Windows, use machine GUID
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                string? machineGuid = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\Cryptography")?.GetValue("MachineGuid") as string;
                if (!string.IsNullOrEmpty(machineGuid))
                {
                    return machineGuid;
                }
            }
            
            // For Linux/Mac/fallback Windows - use MAC address of first network interface
            // or some hardware ID that's stable across reboots
            string machineId = "";
            
            // Try to read machine-id from Linux
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && File.Exists("/etc/machine-id"))
            {
                machineId = File.ReadAllText("/etc/machine-id").Trim();
            }
            // For macOS
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && 
                     File.Exists("/Library/Preferences/SystemConfiguration/com.apple.computer.plist"))
            {
                // In real implementation, you would parse the plist file
                // For now we'll use a fallback
                machineId = Environment.MachineName;
            }
            
            if (string.IsNullOrEmpty(machineId))
            {
                // Fallback to machine name + OS info
                machineId = Environment.MachineName + RuntimeInformation.OSDescription;
            }
            
            return machineId;
        }
        catch
        {
            // Final fallback - less secure but at least it works
            return Environment.MachineName;
        }
    }
    
    private static byte[] GetSalt()
    {
        // Static salt - in a real implementation you might want to store this
        // securely or derive it from another source
        return Encoding.UTF8.GetBytes("SolimyToWszystkoJebanymMarcfelemToolshSecureSalt-v1.0");
    }
}