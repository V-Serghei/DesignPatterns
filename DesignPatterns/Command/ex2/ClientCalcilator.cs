namespace DesignPatterns.Command.ex2;

public class ClientCalculator
{
    public void Run()
    {
        var receiver = new CalculatorReceiver(10);
        var addCommand = new AddCommand(receiver, 5);

        var invoker = new CalculatorInvoker();
        invoker.SetCommand(addCommand).ExecuteCommand();
        invoker.UndoCommand();
    }
}
