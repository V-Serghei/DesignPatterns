using DesignPatterns.AbstractFactory.Ex1.Interfaces;

namespace DesignPatterns.AbstractFactory.Ex1.Concrete.AWS;


/// <summary>
/// Конкретный продукт для хранения данных в AWS DynamoDB
/// Реализует интерфейс IDataStorage
/// Подразумевается, что это хранилище данных в облаке AWS DynamoDB
/// </summary>
public class DynamoDBStorage: IDataStorage
{
    public void StoreData(string data) => Console.WriteLine($"Storing data in AWS DynamoDB: {data}");
    public string RetrieveData(string id) => $"DynamoDB data for {id}";
}