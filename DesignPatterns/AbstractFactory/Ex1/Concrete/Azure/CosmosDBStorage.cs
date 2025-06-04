using DesignPatterns.AbstractFactory.Ex1.Interfaces;

namespace DesignPatterns.AbstractFactory.Ex1.Concrete.Azure;


/// <summary>
/// Кокнкретный продукт для Azure Cosmos DB
/// Реализует интерфейс IDataStorage
/// Является частью семейства продуктов, создаваемых фабрикой AzureInfrastructureFactory
/// Сам по себе подразумевает хранение данных в облачной базе данных Azure Cosmos DB
/// </summary>
public class CosmosDBStorage: IDataStorage
{
    public void StoreData(string data) => Console.WriteLine($"Storing data in Azure Cosmos DB: {data}");
    public string RetrieveData(string id) => $"Cosmos DB data for {id}";
}