using DesignPatterns.Strategy.ex1;
using DesignPatterns.Strategy.ex2;

namespace DesignPatterns.Client.Strategy;

public class StrategyClient
{
    public void Run()
    {
        // Create an order
        var order = new Order( new StandardShippingStrategy(),"A12345", 99.99m, 2.5m, "123 Main St, Anytown");
            
        Console.WriteLine("Order with Standard shipping:");
        order.DisplayOrderSummary();
            
        // Switch to express shipping
        Console.WriteLine("Order with Express shipping:");
        order.SetShippingStrategy(new ExpressShippingStrategy());
        order.DisplayOrderSummary();
            
        // Apply free shipping (maybe for orders over $100)
        Console.WriteLine("Order with Free shipping (promotional):");
        order.SetShippingStrategy(new FreeShippingStrategy());
        order.DisplayOrderSummary();
        
        
        
        
        Console.WriteLine("-------------------------");
        
        var hashContext = new HashContext(new SHA256HashStrateg());
        string input = "Hello, World!";
        string hash = hashContext.Hash(input);
        Console.WriteLine($"Hash: {hash}");
        Console.WriteLine($"Description: {hashContext.Description}");
        Console.WriteLine($"Valid: {hashContext.IsValid(input, hash)}");
    }
}