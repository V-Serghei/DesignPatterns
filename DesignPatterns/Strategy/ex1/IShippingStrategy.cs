namespace DesignPatterns.Strategy.ex1;


/// <summary>
/// Интерфейс стратегии для расчета стоимости доставки.
/// </summary>
public interface IShippingStrategy
{
    decimal CalculateShippingCost(Order order);
    string Description { get; }
}