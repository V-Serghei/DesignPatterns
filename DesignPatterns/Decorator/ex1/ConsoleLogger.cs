namespace DesignPatterns.Decorator.ex1;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($" ЛOГИРОВАНИЕ: {message}");
    }
}