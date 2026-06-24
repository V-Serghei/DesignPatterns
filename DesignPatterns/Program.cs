using DesignPatterns.Client.AbstractFactory;
using DesignPatterns.Client.ADAPTER;
using DesignPatterns.Client.BRIDGE;
using DesignPatterns.Client.Builder;
using DesignPatterns.Client.ChainOfResponsibility;
using DesignPatterns.Client.Command;
using DesignPatterns.Client.Composite;
using DesignPatterns.Client.Decorator;
using DesignPatterns.Client.Facade;
using DesignPatterns.Client.Flyweight;
using DesignPatterns.Client.Mediator;
using DesignPatterns.Client.Memento;
using DesignPatterns.Client.Observer;
using DesignPatterns.Client.Prototype;
using DesignPatterns.Client.Proxy;
using DesignPatterns.Client.Singleton;
using DesignPatterns.Client.StateClient;
using DesignPatterns.Client.Strategy;
using DesignPatterns.Client.VISITOR;

namespace DesignPatterns;

internal static class Program
{
    private static readonly (string Label, string Name, Action Run)[] Patterns =
    [
        // Creational
        ("1",  "Abstract Factory",       () => new AbstractFactoryClient().Run()),
        ("2",  "Builder",                () => new BuilderClient().Run()),
        ("3",  "Prototype",              () => new PrototypeClient().Run()),
        ("4",  "Singleton",              () => new SingletonClient().Run()),
        // Structural
        ("5",  "Adapter",                () => new ClientAdapter().Run()),
        ("6",  "Bridge",                 () => new ClientBridge().Run()),
        ("7",  "Composite",              () => new ClientComposite().Run()),
        ("8",  "Decorator",              () => new ClientDecorator().Run()),
        ("9",  "Facade",                 () => new ClientFacade().Run()),
        ("10", "Flyweight",              () => new FlyweightClient().Run()),
        ("11", "Proxy",                  () => new ProxyClient().Run()),
        // Behavioral
        ("12", "Chain of Responsibility",() => new ChainOfResponsibilityClient().Run()),
        ("13", "Command",                () => new CommandClient().Run()),
        ("14", "Mediator",               () => new MediatorClient().Run()),
        ("15", "Memento",                () => new MementoClient().Run()),
        ("16", "Observer",               () => new ObserverClient().Run()),
        ("17", "State",                  () => new StateClients().Run()),
        ("18", "Strategy",               () => new StrategyClient().Run()),
        ("19", "Visitor",                () => new VisitorClient().Run()),
    ];

    private static void Main()
    {
        while (true)
        {
            PrintMenu();
            var input = (Console.ReadLine() ?? "").Trim();

            if (input == "0")
            {
                Console.WriteLine("Bye!");
                break;
            }

            var match = Array.Find(Patterns, p => p.Label == input);
            if (match == default)
            {
                Console.WriteLine("Unknown option. Press any key...");
                Console.ReadKey();
                continue;
            }

            Console.Clear();
            Console.WriteLine(new string('═', 52));
            Console.WriteLine($"  {match.Name}");
            Console.WriteLine(new string('═', 52));
            Console.WriteLine();

            try
            {
                match.Run();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR] {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.Write("Press any key to return to menu...");
            Console.ReadKey();
        }
    }

    private static void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║            Design Patterns  —  C# 14             ║");
        Console.WriteLine("╠══════════════════════════════════════════════════╣");
        Console.WriteLine("║  CREATIONAL                                      ║");
        Console.WriteLine("║    [1]  Abstract Factory                         ║");
        Console.WriteLine("║    [2]  Builder                                  ║");
        Console.WriteLine("║    [3]  Prototype                                ║");
        Console.WriteLine("║    [4]  Singleton                                ║");
        Console.WriteLine("╠══════════════════════════════════════════════════╣");
        Console.WriteLine("║  STRUCTURAL                                      ║");
        Console.WriteLine("║    [5]  Adapter                                  ║");
        Console.WriteLine("║    [6]  Bridge                                   ║");
        Console.WriteLine("║    [7]  Composite                                ║");
        Console.WriteLine("║    [8]  Decorator                                ║");
        Console.WriteLine("║    [9]  Facade                                   ║");
        Console.WriteLine("║    [10] Flyweight                                ║");
        Console.WriteLine("║    [11] Proxy                                    ║");
        Console.WriteLine("╠══════════════════════════════════════════════════╣");
        Console.WriteLine("║  BEHAVIORAL                                      ║");
        Console.WriteLine("║    [12] Chain of Responsibility                  ║");
        Console.WriteLine("║    [13] Command                                  ║");
        Console.WriteLine("║    [14] Mediator                                 ║");
        Console.WriteLine("║    [15] Memento                                  ║");
        Console.WriteLine("║    [16] Observer                                 ║");
        Console.WriteLine("║    [17] State                                    ║");
        Console.WriteLine("║    [18] Strategy                                 ║");
        Console.WriteLine("║    [19] Visitor                                  ║");
        Console.WriteLine("╠══════════════════════════════════════════════════╣");
        Console.WriteLine("║    [0]  Exit                                     ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝");
        Console.Write("\n  Select pattern: ");
    }
}
