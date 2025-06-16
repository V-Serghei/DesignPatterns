namespace DesignPatterns.Strategy.ex1;


/// <summary>
/// Основной класс, контекст для стратегии доставки.
///
/// </summary>
public class Order
{
    public string OrderId { get; }
    public decimal TotalAmount { get; }
    public decimal Weight { get; } 
    public string Destination { get; }
        
    private IShippingStrategy _shippingStrategy;

    public Order( IShippingStrategy shippingStrategy,
        string orderId, decimal totalAmount, decimal weight, string destination)
    {
        _shippingStrategy = shippingStrategy;
        OrderId = orderId;
        TotalAmount = totalAmount;
        Weight = weight;
        Destination = destination;
            
    }
    public void SetShippingStrategy(IShippingStrategy shippingStrategy)
    {
        _shippingStrategy = shippingStrategy;
    }

    public decimal CalculateTotal()
    {
        decimal shippingCost = _shippingStrategy.CalculateShippingCost(this);
        return TotalAmount + shippingCost;
    }

    public void DisplayOrderSummary()
    {
        decimal shippingCost = _shippingStrategy.CalculateShippingCost(this);
            
        Console.WriteLine($"Order: {OrderId}");
        Console.WriteLine($"Shipping to: {Destination}");
        Console.WriteLine($"Shipping method: {_shippingStrategy.Description}");
        Console.WriteLine($"Order amount: ${TotalAmount:F2}");
        Console.WriteLine($"Shipping cost: ${shippingCost:F2}");
        Console.WriteLine($"Total: ${CalculateTotal():F2}");
        Console.WriteLine();
    }
}