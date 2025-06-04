using DesignPatterns.AbstractFactory.Ex1.Concrete.Azure;
using DesignPatterns.AbstractFactory.Ex1.Interfaces;

namespace DesignPatterns.AbstractFactory.Ex1.Concrete;


/// <summary>
/// Кокнкретная фабрика для Azure
/// </summary>
public class AzureInfrastructureFactory: ICloudInfrastructureFactory
{
    public IDataStorage CreateDataStorage() => new CosmosDBStorage();
    public IAuthService CreateAuthService() => new AzureADAuthService();
    public IMessageQueue CreateMessageQueue() => new ServiceBusMessageQueue();
}