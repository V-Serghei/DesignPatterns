namespace DesignPatterns.Strategy.ex2;

public interface IHashStrategy
{
    string Hash(string input);
    string Description { get; } 
    bool IsValid(string input, string hash);
    
}