namespace DesignPatterns.Decorator.ex1;

public class SimpleAnalyticsService : IAnalyticsService
{
    public void TrackEvent(string eventName, Dictionary<string, string> properties)
    {
        Console.WriteLine($"📊 АНАЛИТИКА: событие '{eventName}'");
        foreach (var prop in properties)
        {
            Console.WriteLine($"   {prop.Key}: {prop.Value}");
        }
    }
}