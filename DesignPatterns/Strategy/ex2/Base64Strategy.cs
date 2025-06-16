namespace DesignPatterns.Strategy.ex2;

public class Base64Strategy: IHashStrategy
{
    public string Hash(string input)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(input);
        return System.Convert.ToBase64String(bytes);
    }

    public string Description => "Base64 Encoding";

    public bool IsValid(string input, string hash)
    {
        var computedHash = Hash(input);
        return computedHash == hash;
    }
}