namespace DesignPatterns.Strategy.ex1;


/// <summary>
/// Конкретная стратегия для экспресс-доставки.
/// </summary>
public class ExpressShippingStrategy: IShippingStrategy
{
    public string Description => "Express Shipping (1-2 business days)";

    public decimal CalculateShippingCost(Order order)
    {
        // Higher base rate + higher cost per kg
        return 15.00m + (order.Weight * 1.0m);
    }
}