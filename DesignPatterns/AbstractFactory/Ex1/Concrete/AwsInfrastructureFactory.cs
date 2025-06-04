using DesignPatterns.AbstractFactory.Ex1.Concrete.AWS;
using DesignPatterns.AbstractFactory.Ex1.Interfaces;

namespace DesignPatterns.AbstractFactory.Ex1.Concrete;


/// <summary>
/// Кокнкретная фабрика для AWS
/// </summary>
public class AwsInfrastructureFactory: ICloudInfrastructureFactory
{
    public IDataStorage CreateDataStorage() => new DynamoDBStorage();
    public IAuthService CreateAuthService() => new CognitoAuthService();
    public IMessageQueue CreateMessageQueue() => new SQSMessageQueue();
}