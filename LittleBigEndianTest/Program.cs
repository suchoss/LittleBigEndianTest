// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var fileBytes = File.ReadAllBytes("testfile.txt");

var checksumAsIs = GetChecksumAsIs(fileBytes);
var checksumConverted = GetChecksumConvertedToBE(fileBytes);

Console.WriteLine($"Is current architecture LE = {BitConverter.IsLittleEndian}");
Console.WriteLine($"Checksum as is: [{checksumAsIs}]");
Console.WriteLine($"Checksum converted to BE: [{checksumConverted}]");




string GetChecksumAsIs(byte[] file)
{
    var hash = System.Security.Cryptography.SHA256.HashData(file);
    return BitConverter.ToString(hash).Replace("-", "");
}

string GetChecksumConvertedToBE(byte[] file)
{
    var hash = System.Security.Cryptography.SHA256.HashData(file);
    if (BitConverter.IsLittleEndian)
    {
        return BitConverter.ToString(hash).Replace("-", "");
    }
    else
    {
        return BitConverter.ToString(hash.Reverse().ToArray()).Replace("-", "");
    }
}