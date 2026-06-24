using DesignPatterns.AbstractFactory.Ex1;
using DesignPatterns.AbstractFactory.Ex1.Concrete;

namespace DesignPatterns.Client.AbstractFactory;

public class AbstractFactoryClient
{
    public void Run()
    {
        Console.WriteLine("=== AWS Infrastructure ===");
        var awsApp = new WebApplication(new AwsInfrastructureFactory());
        awsApp.RunApplication();

        Console.WriteLine("\n=== Azure Infrastructure ===");
        var azureApp = new WebApplication(new AzureInfrastructureFactory());
        azureApp.RunApplication();
    }
}
