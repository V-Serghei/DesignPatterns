namespace DesignPatterns.Decorator.ex1;

public class EmailNotificationService : INotificationService
{
    public void SendNotification(string recipient, string subject, string message)
    {
        Console.WriteLine($"📧 УВЕДОМЛЕНИЕ для {recipient}");
        Console.WriteLine($"   Тема: {subject}");
        Console.WriteLine($"   Сообщение: {message}");
    }
}