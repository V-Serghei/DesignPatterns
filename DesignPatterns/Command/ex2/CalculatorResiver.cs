namespace DesignPatterns.Command.ex2;

public class CalculatorResiver
{
    private int _result;
    
    public CalculatorResiver(int initialValue)
    {
        _result = initialValue;
    }
    
    public void Add(int value)
    {
        _result += value;
        Console.WriteLine($"Результат после сложения: {_result}");
    }
    
    public void Subtract(int value)
    {
        _result -= value;
        Console.WriteLine($"Результат после вычитания: {_result}");
    }
    
    public void Multiply(int value)
    {
        _result *= value;
        Console.WriteLine($"Результат после умножения: {_result}");
    }
}