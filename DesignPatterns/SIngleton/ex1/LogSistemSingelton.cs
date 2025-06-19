namespace DesignPatterns.SIngleton.ex1;

public class LogSistemSingelton
{
    private static LogSistemSingelton _instance ;
    private static readonly object _lock = new object();

    private LogSistemSingelton()
    { }

    public static LogSistemSingelton Instance
    {
        get  {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LogSistemSingelton();
                    }
                }
            }

            return _instance;
        }
        
    }
    
    // public void Log (MessageModel message)
    // {
    //     // Logika logowania
    //     Console.WriteLine($"[{DateTime.Now}] {message.Level}: {message.Content}");
    // }
    
    
    
}
