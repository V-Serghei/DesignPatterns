namespace DesignPatterns.Command.ex2;

public class CalculatorReceiver
{
    private int _result;

    public CalculatorReceiver(int initialValue)
    {
        _result = initialValue;
    }

    public void Add(int value)
    {
        _result += value;
        Console.WriteLine($"After add: {_result}");
    }

    public void Subtract(int value)
    {
        _result -= value;
        Console.WriteLine($"After subtract: {_result}");
    }

    public void Multiply(int value)
    {
        _result *= value;
        Console.WriteLine($"After multiply: {_result}");
    }
}
