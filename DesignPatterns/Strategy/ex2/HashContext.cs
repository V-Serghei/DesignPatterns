namespace DesignPatterns.Strategy.ex2;

public class HashContext
{
    private readonly IHashStrategy _hashStrategy;
    private string _hash;

    public HashContext(IHashStrategy hashStrategy)
    {
        _hashStrategy = hashStrategy;
    }

    public string Hash(string input)
    {
        _hash = _hashStrategy.Hash(input);
        return _hash;
    }

    public bool IsValid(string input, string hash)
    {
        var result = _hashStrategy.IsValid(input, hash);
        return result;
        
    }

    public string Description => _hashStrategy.Description;
    
    public string GetHash()
    {
        return _hash;
    }
}