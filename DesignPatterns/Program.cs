using DesignPatterns.AbstractFactory.Ex1;
using DesignPatterns.AbstractFactory.Ex1.Concrete;
using DesignPatterns.FactoryMethod.Ex1.abstracts;
using DesignPatterns.FactoryMethod.Ex1.concrete;

namespace DesignPatterns;

internal static class Program
{
    private static void Main(string[] args)
    {
        //This is a simple demonstration of working
        //with design patterns in C#.
        
        //Using the Factory Method pattern to create
        Document pdf = new PdfDocument("example.pdf");
        Document word = new WordDocument("example.docx");
        
        pdf.Process();
        Console.WriteLine("////////////////////////////");
        word.Process();
        
        Console.WriteLine("////////////////////////////");
        Console.WriteLine("////////////////////////////");
        Console.WriteLine("////////////////////////////");
        
        //Using the Abstract Factory pattern to create
        //a family of related objects.
        Console.WriteLine("Creating a web application with AWS architecture:");
        WebApplication awsApp = new WebApplication(new AwsInfrastructureFactory());
        awsApp.RunApplication();

        Console.WriteLine("\n--------------------------\n");

        Console.WriteLine("Creating a web application with Azure architecture:");
        WebApplication azureApp = new WebApplication(new AzureInfrastructureFactory());
        azureApp.RunApplication();
        
        
    }
}