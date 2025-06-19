namespace DesignPatterns.Command.ex2;

public class AddCommand: ICommand
{
    private int _value;
    private CalculatorResiver _calculatorResiver;
    
    public AddCommand(CalculatorResiver calculatorResiver, int value)
    {
        _calculatorResiver = calculatorResiver;
        _value = value;
    }
    
    
    public void Execute()
    {
        _calculatorResiver.Add(_value);
        Console.WriteLine($"Выполнена команда сложения: {_value}");
    }

    public void Undo()
    {
        _calculatorResiver.Subtract(_value);
        Console.WriteLine($"Отменена команда сложения: {_value}");
    }
    
}