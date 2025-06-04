namespace DesignPatterns.AbstractFactory.Ex1.Interfaces;


/// <summary>
/// Интерфейс продукта
/// Использует IAuthService для аутентификации пользователей
/// </summary>
public interface IMessageQueue
{
    void SendMessage(string message);
    void ProcessMessages(IAuthService authService);
}