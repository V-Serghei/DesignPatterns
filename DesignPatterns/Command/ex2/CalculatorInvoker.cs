namespace DesignPatterns.Command.ex2;

public class CalculatorInvoker
{
    public ICommand _commands;
    Stack<ICommand?> _history = new Stack<ICommand?>();
    public CalculatorInvoker SetCommand(ICommand command)
    {
        _commands = command;
        return this;
    }

    public void ExecuteCommand()
    {
        var command = _commands;
        if (command == null)
        {
            Console.WriteLine("No command set to execute.");
            return;
        }
        command.Execute();
        
        _history.Push(_commands);
    }
    public void UndoCommand()
    {
        _history.Pop()!.Undo();
    }
}