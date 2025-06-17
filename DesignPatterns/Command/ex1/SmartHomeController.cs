namespace DesignPatterns.Command.ex1;

public class SmartHomeController
{
    private readonly Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();
    private readonly Stack<ICommand> _history = new Stack<ICommand>();
    

    public void RegisterCommand(string name, ICommand command)
    {
        _commands[name] = command;
    }

    public void ExecuteCommand(string name)
    {
        if (_commands.TryGetValue(name, out ICommand command))
        {
            command.Execute();
            _history.Push(command);
            Console.WriteLine($"Command '{command.Description}' executed and added to history");
        }
        else
        {
            Console.WriteLine($"Command '{name}' not found");
        }
    }

    public void UndoLastCommand()
    {
        if (_history.Count > 0)
        {
            ICommand command = _history.Pop();
            Console.WriteLine($"Undoing: {command.Description}");
            command.Undo();
        }
        else
        {
            Console.WriteLine("No commands to undo");
        }
    }

    public void ShowCommandHistory()
    {
        Console.WriteLine("\n=== Command History ===");
        if (_history.Count == 0)
        {
            Console.WriteLine("No commands executed yet");
            return;
        }

        int i = _history.Count;
        foreach (var command in _history)
        {
            Console.WriteLine($"{i--}. {command.Description}");
        }
    }

    public void ShowAvailableCommands()
    {
        Console.WriteLine("\n=== Available Commands ===");
        foreach (var cmd in _commands)
        {
            Console.WriteLine($"- {cmd.Key}: {cmd.Value.Description}");
        }
    }
}