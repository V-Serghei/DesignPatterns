namespace DesignPatterns.Command.ex2;

public class AddCommand : ICommand
{
    private readonly int _value;
    private readonly CalculatorReceiver _receiver;

    public AddCommand(CalculatorReceiver receiver, int value)
    {
        _receiver = receiver;
        _value = value;
    }

    public void Execute()
    {
        _receiver.Add(_value);
        Console.WriteLine($"Executed Add({_value})");
    }

    public void Undo()
    {
        _receiver.Subtract(_value);
        Console.WriteLine($"Undone Add({_value})");
    }
}
