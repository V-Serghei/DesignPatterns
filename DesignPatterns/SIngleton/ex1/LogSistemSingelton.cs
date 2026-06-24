namespace DesignPatterns.SIngleton.ex1;

public enum LogLevel { Debug, Info, Warning, Error }

public class AppLogger
{
    private static AppLogger? _instance;
    private static readonly object _lock = new();
    private readonly List<string> _history = new();

    private AppLogger() { }

    public static AppLogger Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new AppLogger();
                }
            }
            return _instance;
        }
    }

    public void Log(string message, LogLevel level = LogLevel.Info)
    {
        var entry = $"[{DateTime.Now:HH:mm:ss}] [{level.ToString().ToUpper(),-7}] {message}";
        _history.Add(entry);
        Console.WriteLine(entry);
    }

    public void PrintHistory()
    {
        Console.WriteLine("\n--- Log history ---");
        foreach (var entry in _history)
            Console.WriteLine(entry);
    }
}
