using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace BuddyCLI.Core;

public class EncryptionHelper
{
    private static byte[] GetSalt()
    {
        // Static salt - in a real implementation you might want to store this
        // securely or derive it from another source
        return "SolimyToWszystkoJebanymMarcfelemToolshSecureSalt-v1.0"u8.ToArray();
    }
    
    // Gets a unique identifier for the machine
    private static string GetMachineKey()
    {
        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                string? machineGuid = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\Cryptography")?.GetValue("MachineGuid") as string;
                if (!string.IsNullOrEmpty(machineGuid)) return machineGuid;
            }
            string machineId = "";
            
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && File.Exists("/etc/machine-id"))
                machineId = File.ReadAllText("/etc/machine-id").Trim();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && 
                File.Exists("/Library/Preferences/SystemConfiguration/com.apple.computer.plist"))
            {
                machineId = Environment.MachineName;
            }
            
            if (string.IsNullOrEmpty(machineId)) 
                machineId = Environment.MachineName + RuntimeInformation.OSDescription;
            
            return machineId;
        }
        catch
        {
            return Environment.MachineName;
        }
    }
    
    private static (byte[] key, byte[] iv) _generateKeyAndIV()
    {
        using var deriveBytes = new Rfc2898DeriveBytes(GetMachineKey() + Environment.UserName, GetSalt(), 10000, HashAlgorithmName.SHA512);
        byte[] key = deriveBytes.GetBytes(32); // 256 bits for AES-256
        byte[] iv = deriveBytes.GetBytes(16);  // 128 bits for IV
        return (key, iv);
    }
    
    public static byte[] Encrypt(string plainText)
    {
        (byte[] Key, byte[] IV) = _generateKeyAndIV();

        using Aes aesAlg = Aes.Create();
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        // Create the streams used for encryption.
        using MemoryStream msEncrypt = new MemoryStream();
        using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
        {
            //Write all data to the stream.
            swEncrypt.Write(plainText);
        }
        byte[] encrypted = msEncrypt.ToArray();

        // Return the encrypted bytes from the memory stream.
        return encrypted;
    }

    public static string Decrypt(byte[] cipherText)
    {
        (byte[] Key, byte[] IV) = _generateKeyAndIV();

        using Aes aesAlg = Aes.Create();
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        // Create a decryptor to perform the stream transform.
        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        // Create the streams used for decryption.
        using MemoryStream msDecrypt = new MemoryStream(cipherText);
        using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using StreamReader srDecrypt = new StreamReader(csDecrypt);
        string plaintext = srDecrypt.ReadToEnd();

        return plaintext;
    }
}