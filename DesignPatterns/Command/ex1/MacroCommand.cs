namespace DesignPatterns.Command.ex1;

public class MacroCommand :ICommand
{
private readonly List<ICommand> _commands;
private readonly string _name;

public MacroCommand(string name, List<ICommand> commands)
{
    _name = name;
    _commands = commands;
}

public void Execute()
{
    Console.WriteLine($"Executing macro: {_name}");
    foreach (var command in _commands)
    {
        command.Execute();
    }
}

public void Undo()
{
    Console.WriteLine($"Undoing macro: {_name}");
    // Execute commands in reverse order for proper undo
    for (int i = _commands.Count - 1; i >= 0; i--)
    {
        _commands[i].Undo();
    }
}

public string Description => $"Macro: {_name} ({_commands.Count} commands)";
}
