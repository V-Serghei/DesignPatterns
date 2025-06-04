namespace DesignPatterns.AbstractFactory.Ex1.Interfaces;


/// <summary>
/// Интерфейс абстрактной фабрики
/// </summary>
public interface ICloudInfrastructureFactory
{
    IDataStorage CreateDataStorage();
    IAuthService CreateAuthService();
    IMessageQueue CreateMessageQueue();
}