namespace DesignPatterns.AbstractFactory.Ex1.Interfaces;


/// <summary>
/// Интерфейс продукта
/// Использует IDataStorage для хранения данных
/// </summary>
public interface IAuthService
{
    bool AuthenticateUser(string user, string password);
    void RegisterUser(string user, string password);
    void SetDataStorage(IDataStorage storage);
}