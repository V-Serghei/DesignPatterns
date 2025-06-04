using DesignPatterns.AbstractFactory.Ex1.Interfaces;

namespace DesignPatterns.AbstractFactory.Ex1.Concrete.AWS;


/// <summary>
/// Конкретный продукт аутентификации пользователей в AWS Cognito
/// Реализует интерфейс IAuthService
/// Включает зависимость от IDataStorage для хранения данных пользователей
/// Подразумевается, что это сервис аутентификации в облаке AWS Cognito
/// </summary>
public class CognitoAuthService: IAuthService
{
    private IDataStorage _storage;

    public bool AuthenticateUser(string user, string password)
    {
        Console.WriteLine($"Authenticating {user} with AWS Cognito");
        string userData = _storage.RetrieveData(user);
        Console.WriteLine($"Using user data: {userData}");
        return true;
    }

    public void RegisterUser(string user, string password)
    {
        Console.WriteLine($"Registering {user} in AWS Cognito");
        _storage.StoreData($"User {user} registered in Cognito");
    }

    public void SetDataStorage(IDataStorage storage)
    {
        _storage = storage;
        Console.WriteLine("AWS Cognito now using DynamoDB for storage");
    }
}