using DesignPatterns.SIngleton.ex1;

namespace DesignPatterns.Client.Singleton;

public class SingletonClient
{
    public void Run()
    {
        var logger1 = AppLogger.Instance;
        var logger2 = AppLogger.Instance;

        Console.WriteLine($"logger1 and logger2 are the same instance: {ReferenceEquals(logger1, logger2)}");
        Console.WriteLine();

        logger1.Log("Application started", LogLevel.Info);
        logger1.Log("Loading configuration...", LogLevel.Debug);
        logger2.Log("Config loaded successfully", LogLevel.Info);
        logger2.Log("Database connection failed", LogLevel.Error);
        logger1.Log("Retrying connection...", LogLevel.Warning);

        logger1.PrintHistory();
    }
}
