using DesignPatterns.AbstractFactory.Ex1.Interfaces;

namespace DesignPatterns.AbstractFactory.Ex1.Concrete.Azure;


/// <summary>
/// Является конкретным продуктом для Azure Service Bus
/// Реализует интерфейс IMessageQueue
/// Использует IAuthService для аутентификации пользователей
/// Предназначен для отправки и обработки сообщений в очереди Azure Service Bus
/// </summary>
public class ServiceBusMessageQueue: IMessageQueue
{
    public void SendMessage(string message) => 
        Console.WriteLine($"Sending message to Azure Service Bus: {message}");
            
    public void ProcessMessages(IAuthService authService)
    {
        Console.WriteLine("Processing messages from Azure Service Bus queue");
        authService.AuthenticateUser("system", "password");
    }
}