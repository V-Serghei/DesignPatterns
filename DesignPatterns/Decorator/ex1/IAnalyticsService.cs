namespace DesignPatterns.Decorator.ex1;

public interface IAnalyticsService
{
    void TrackEvent(string eventName, Dictionary<string, string> properties);
}