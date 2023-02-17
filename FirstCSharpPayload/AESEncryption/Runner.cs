using System.Security.Cryptography;
using FirstCSharpPayload;

var aes = new AesEncryption();



while (true)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("0: Exit");
    Console.WriteLine("1: Encrypt a file");
    Console.WriteLine("2: Decrypt a file");

    Console.Write("> ");
    var input = Console.ReadLine();

    if (input.Equals("0"))
    {
        break;
    }
    else if (input.Equals("1"))
    {
        Console.Write("Data to Encrypt: ");
        var data = Console.ReadLine();
        Console.Write("Output FilePath: ");
        var filepath = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();
        
        var encrypted = await aes.EncryptAsync(data, password);
        aes.GetIV();
        aes.SaveByteArrayToFile(encrypted, filepath);
    }
    else if (input.Equals("2"))
    {
        byte[] iv = Console.ReadLine();
        var encrypted = aes.ReadEncryptedDataFromFile(filepath, iv);
        var decrypted = await aes.DecryptAsync(encrypted, passphrase);
        Console.WriteLine(decrypted);
    }
}














/*




aes.SaveByteArrayToFile(encrypted, filepath);
var encrypted2 = File.ReadAllBytes(filepath);
Console.WriteLine($"Encrypted data: {BitConverter.ToString(encrypted)}");

var decrypted = await aes.DecryptAsync(encrypted, passphrase);

Console.WriteLine($"Decrypted data: {decrypted}");
*/

