namespace DesignPatterns.Strategy.ex2;

public class SHA256HashStrateg : IHashStrategy
{
    public string Hash(string input)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var bytes = System.Text.Encoding.UTF8.GetBytes(input);
        var hashBytes = sha256.ComputeHash(bytes);
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
    }

    public string Description => "SHA-256 Hashing";

    public bool IsValid(string input, string hash)
    {
        var computedHash = Hash(input);
        return computedHash == hash;
    }
}