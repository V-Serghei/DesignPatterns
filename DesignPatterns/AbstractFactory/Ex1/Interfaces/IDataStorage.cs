namespace DesignPatterns.AbstractFactory.Ex1.Interfaces;


/// <summary>
/// Интерфейс продукта 
/// </summary>
public interface IDataStorage
{
    void StoreData(string data);
    string RetrieveData(string id);
}