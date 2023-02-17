using System.Security.Cryptography;
using System.Text;

namespace FirstCSharpPayload;

public class AesEncryption
{
    private byte[] IV;

    public AesEncryption()
    {
        // generate and store IV for later
        var aes = Aes.Create();
        aes.GenerateIV();
        IV = aes.IV;
    }
    
    private byte[] DeriveKeyFromPassword(string password)
    {
        var emptySalt = Array.Empty<byte>();
        var iterations = 1000;
        var desiredKeyLength = 16; // 16 bytes equal 128 bits.
        var hashMethod = HashAlgorithmName.SHA384;
        return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(password),
            emptySalt,
            iterations,
            hashMethod,
            desiredKeyLength);
    }
    
    public async Task<byte[]> EncryptAsync(string clearText, string passphrase)
    {
        using var aes = Aes.Create();
        aes.Key = DeriveKeyFromPassword(passphrase);
        aes.IV = IV;

        using MemoryStream output = new();
        using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);

        await cryptoStream.WriteAsync(Encoding.Unicode.GetBytes(clearText));
        await cryptoStream.FlushFinalBlockAsync();
        
        return output.ToArray();
    }
    
    public async Task<string> DecryptAsync(byte[] encrypted, string passphrase)
    {
        using var aes = Aes.Create();
        aes.Key = DeriveKeyFromPassword(passphrase);
        aes.IV = IV;

        using MemoryStream input = new(encrypted);
        using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);

        using MemoryStream output = new();
        await cryptoStream.CopyToAsync(output);

        return Encoding.Unicode.GetString(output.ToArray());
    }
    
    public void SaveByteArrayToFile(byte[] data, string filePath)
    {
        using var writer = new BinaryWriter(File.OpenWrite(filePath));
        writer.Write(data);
        writer.Close();
        
        Console.WriteLine($"Encrypted data written to: {filePath}");
    }

    public byte[] ReadEncryptedDataFromFile(string filepath, byte[] iv)
    {
        IV = iv;
        return File.ReadAllBytes(filepath);
    }

    public void GetIV()
    {
        var bytes = (BitConverter.ToString(IV)).Split("-");
        
        Console.Write("{ ");
        foreach (var chunk in bytes)
        {
            Console.Write($"0x{chunk}, ");
        }
        Console.WriteLine("};");
    }
}