using DesignPatterns.AbstractFactory.Ex1;
using DesignPatterns.AbstractFactory.Ex1.Concrete;
using DesignPatterns.AbstractFactory.Ex1.Interfaces;
using DesignPatterns.BUILDER;
using DesignPatterns.BUILDER.Ex1;
using DesignPatterns.Client.ADAPTER;
using DesignPatterns.Client.ChainOfResponsibility;
using DesignPatterns.Client.Command;
using DesignPatterns.Client.Composite;
using DesignPatterns.Client.Decorator;
using DesignPatterns.Client.Facade;
using DesignPatterns.Client.Flyweight;
using DesignPatterns.Client.Mediator;
using DesignPatterns.Client.Memento;
using DesignPatterns.Client.Observer;
using DesignPatterns.Client.Proxy;
using DesignPatterns.Client.StateClient;
using DesignPatterns.Client.Strategy;
using DesignPatterns.Client.VISITOR;
using DesignPatterns.Composite.ex2;
using DesignPatterns.FactoryMethod;
using DesignPatterns.FactoryMethod.Ex1.abstracts;
using DesignPatterns.FactoryMethod.Ex1.concrete;
using DesignPatterns.FactoryMethod.Ex2.abstracts;
using DesignPatterns.FactoryMethod.Ex2.concrete;
using DesignPatterns.PROTOTYPE.Ex1;

namespace DesignPatterns;

internal static class Program
{
    private static void Main(string[] args)
    {

        if (false)
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

            Console.WriteLine("\n--------------------------\n");
            Console.WriteLine("////////////////////////////");
            Console.WriteLine("////////////////////////////");
            Console.WriteLine("////////////////////////////");
            Console.WriteLine("\n--------------------------\n");

            // Create character prototypes
            var warriorPrototype = new Warrior
            {
                Health = 100,
                Strength = 15,
                Defense = 10,
                WeaponType = "Sword",
                Equipment = new List<string> { "Shield", "Helmet", "Chainmail" }
            };

            var archerPrototype = new Archer
            {
                Health = 80,
                Strength = 8,
                Defense = 5,
                RangeDistance = 100,
                Equipment = new List<string> { "Bow", "Quiver", "Leather Armor" }
            };

            // Store prototypes in registry
            CharacterRegistry registry = new CharacterRegistry();
            registry.AddPrototype("warrior", warriorPrototype);
            registry.AddPrototype("archer", archerPrototype);

            // Clone characters from prototypes
            Console.WriteLine("Creating characters from prototypes:");

            var warrior1 = registry.GetClone("warrior") as Warrior;
            warrior1.Name = "Aragorn";

            var warrior2 = registry.GetClone("warrior") as Warrior;
            warrior2.Name = "Boromir";
            warrior2.Health = 90;
            warrior2.Equipment.Add("Horn of Gondor");

            var archer1 = registry.GetClone("archer") as Archer;
            archer1.Name = "Legolas";
            archer1.RangeDistance = 120;

            // Display characters
            Console.WriteLine("\nWarrior 1:");
            warrior1.Display();

            Console.WriteLine("\nWarrior 2:");
            warrior2.Display();

            Console.WriteLine("\nArcher 1:");
            archer1.Display();

            // Verify deep copying works correctly
            Console.WriteLine("\nModifying original prototype equipment...");
            warriorPrototype.Equipment.Clear();
            warriorPrototype.Equipment.Add("Modified Equipment");

            Console.WriteLine("\nWarrior 1 after prototype modification (should be unchanged):");
            warrior1.Display();
        }
        // var adapter = new ClientAdapter();
        // adapter.Run();

        
        // var bridge = new ClientBridge();
        // bridge.Run();
        
        // var composite = new ClientComposite();
        // composite.Run();
        
        
        // var decorator = new ClinentDecorator();
        // decorator.Run();
        
        // var facade = new ClientFacade();
        // facade.Run();
        
        // var state = new StateClients();
        // state.Run();
        
        // var strategy = new StrategyClient();
        // strategy.Run();
        
        // var proxy = new ProxyClient();
        // proxy.Run();
        
        // var momento = new MementoClient();
        // momento.Run();
        
        // var observer = new ObserverClient();
        // observer.Run();
        
        // var chainOfResponsibility = new ChainOfResponsibilityClient();
        // chainOfResponsibility.Run();
        //
        // var builderComposite = new CategoryTreeBuilder();
        // var categoryTree = builderComposite.BuildCategoryTree();
        //
        // Console.WriteLine("\n=== Дерево категорий ===");
        // categoryTree.Display(0);


        // var commandCLietn = new CommandClient();
        // commandCLietn.Run();
        // var visitorClient = new VisitorClient();
        // visitorClient.Run();
        //
        // var mediatorClient = new MediatorClient();
        // mediatorClient.Run();
        
        var flyweightClient = new FlyweightClient();
        flyweightClient.Run();
    }
}