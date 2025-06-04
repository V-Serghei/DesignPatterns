using DesignPatterns.AbstractFactory.Ex1.Interfaces;

namespace DesignPatterns.AbstractFactory.Ex1.Concrete.AWS;

public class MangoDbStorege:IDataStorage
{
    public void StoreData(string data)
    {
        Console.WriteLine($"Storing data in AWS MangoDB: {data}");
    }

    public string RetrieveData(string id)
    {
        return $"MangoDB data for {id}";
    }
}