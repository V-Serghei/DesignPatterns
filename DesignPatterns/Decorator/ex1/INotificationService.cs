namespace DesignPatterns.Decorator.ex1;

public interface INotificationService
{
    void SendNotification(string recipient, string subject, string message);
}