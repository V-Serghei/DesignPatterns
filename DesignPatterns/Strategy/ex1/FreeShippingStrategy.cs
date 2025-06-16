namespace DesignPatterns.Strategy.ex1;

/// <summary>
/// конкретная стратегия для бесплатной доставки.
/// </summary>
public class FreeShippingStrategy: IShippingStrategy
{
    public string Description => "Free Shipping (5-7 business days)";

    public decimal CalculateShippingCost(Order order)
    {
        return 0.0m;
    }
}