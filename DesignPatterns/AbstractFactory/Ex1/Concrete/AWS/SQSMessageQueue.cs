using DesignPatterns.AbstractFactory.Ex1.Interfaces;

namespace DesignPatterns.AbstractFactory.Ex1.Concrete;


/// <summary>
/// Кокнкретный продукт для работы с очередями сообщений в AWS SQS
/// Реализует интерфейс IMessageQueue
/// Имеет зависимость от IAuthService для аутентификации пользователя
/// Подразумевает, что сообщения отправляются в очередь SQS
/// </summary>
public class SQSMessageQueue: IMessageQueue
{
    public void SendMessage(string message) => Console.WriteLine($"Sending message to AWS SQS: {message}");
        
    public void ProcessMessages(IAuthService authService)
    {
        if (authService == null) throw new ArgumentNullException(nameof(authService));
        Console.WriteLine("Processing messages from AWS SQS queue");
        authService.AuthenticateUser("system", "password");
    }
}