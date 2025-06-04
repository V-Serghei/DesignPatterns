using DesignPatterns.AbstractFactory.Ex1.Interfaces;

namespace DesignPatterns.AbstractFactory.Ex1;


/// <summary>
/// Клиентский код, использующий абстрактную фабрику для создания компонентов веб-приложения.
/// </summary>
public class WebApplication
{
    private readonly IDataStorage _storage;
    private readonly IAuthService _authService;
    private readonly IMessageQueue _messageQueue;

    public WebApplication(ICloudInfrastructureFactory factory)
    {
        _storage = factory.CreateDataStorage();
        _authService = factory.CreateAuthService();
        _messageQueue = factory.CreateMessageQueue();
            
        _authService.SetDataStorage(_storage);
    }

    public void RunApplication()
    {
        _authService.RegisterUser("john", "password123");
        _authService.AuthenticateUser("john", "password123");
        _messageQueue.SendMessage("Hello from web app");
        _messageQueue.ProcessMessages(_authService);
    }
}
