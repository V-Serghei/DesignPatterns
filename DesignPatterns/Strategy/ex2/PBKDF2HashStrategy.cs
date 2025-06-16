namespace DesignPatterns.Strategy.ex2;

public class PBKDF2HashStrategy: IHashStrategy

{
    [Obsolete("Obsolete")]
    public string Hash(string input)
    {
        using var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(input, System.Text.Encoding.UTF8.GetBytes("salt"), 10000);
        return Convert.ToBase64String(pbkdf2.GetBytes(32));
    }

    public string Description => "PBKDF2 Hashing";

    [Obsolete("Obsolete")]
    public bool IsValid(string input, string hash)
    {
        var computedHash = Hash(input);
        return computedHash == hash;
    }
}