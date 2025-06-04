using DesignPatterns.AbstractFactory.Ex1.Interfaces;

namespace DesignPatterns.AbstractFactory.Ex1.Concrete.Azure;


/// <summary>
/// Конкретный продукт для Azure Active Directory
/// Реализует интерфейс IAuthService
/// Является частью абстрактной фабрики для Azure
/// Включает зависимость от IDataStorage для хранения данных пользователей
/// Сам по себе подразумевает аутентификацию пользователей через Azure Active Directory
/// </summary>
public class AzureADAuthService: IAuthService
{
    private IDataStorage _storage;

    public bool AuthenticateUser(string user, string password)
    {
        Console.WriteLine($"Authenticating {user} with Azure AD");
        string userData = _storage.RetrieveData(user);
        Console.WriteLine($"Using user data: {userData}");
        return true;
    }

    public void RegisterUser(string user, string password)
    {
        Console.WriteLine($"Registering {user} in Azure AD");
        _storage.StoreData($"User {user} registered in Azure AD");
    }

    public void SetDataStorage(IDataStorage storage)
    {
        _storage = storage;
        Console.WriteLine("Azure AD now using Cosmos DB for storage");
    }
}