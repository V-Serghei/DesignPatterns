using DesignPatterns.AbstractFactory.Ex1;
using DesignPatterns.AbstractFactory.Ex1.Concrete;
using DesignPatterns.BUILDER;
using DesignPatterns.BUILDER.Ex1;
using DesignPatterns.FactoryMethod.Ex1.abstracts;
using DesignPatterns.FactoryMethod.Ex1.concrete;
using DesignPatterns.FactoryMethod.Ex2.abstracts;
using DesignPatterns.FactoryMethod.Ex2.concrete;

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
        
        Sender mailSender = new MailSenderCreator("Hello, this is a test email!");
        mailSender.Send();
        Console.WriteLine("////////////////////////////");
        
        Sender smsSender = new SmsSenderCreator("Hello, this is a test SMS!");
        smsSender.Send();
        
        
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
        
        Console.WriteLine("////////////////////////////");
        Console.WriteLine("////////////////////////////");
        Console.WriteLine("////////////////////////////");
        Console.WriteLine("\n--------------------------\n");
        
        // Using concrete builder directly
        Console.WriteLine("Building a simple GET request:");
        var getBuilder = new HttpRequestBuilder()
            .SetMethod("GET")
            .SetUrl("https://api.example.com/users")
            .AddHeader("Accept", "application/json")
            .AddQueryParameter("page", "1");
                
        HttpRequest getRequest = getBuilder.Build();
        Console.WriteLine(getRequest);
            
        Console.WriteLine("\n--------------------------\n");
            
        // Using director with builder
        Console.WriteLine("Building requests using RequestDirector:");
        var builder = new HttpRequestBuilder();
        var director = new RequestDirector(builder);
            
        HttpRequest apiRequest = director.BuildApiDataRequest("users", "json");
        Console.WriteLine(apiRequest);
            
        Console.WriteLine("\n--------------------------\n");
            
        builder.Reset();
        HttpRequest authRequest = director.BuildAuthRequest("john.doe@example.com", "password123");
        Console.WriteLine(authRequest);
        
        
        
    }
}