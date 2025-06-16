namespace DesignPatterns.Strategy.ex1;



/// <summary>
/// Конкретная стратегия для стандартной доставки.
/// </summary>
public class StandardShippingStrategy: IShippingStrategy
{
    public string Description => "Standard Shipping (3-5 business days)";

    public decimal CalculateShippingCost(Order order)
    {
        // Base rate + cost per kg
        return 5.00m + (order.Weight * 0.5m);
    }
}