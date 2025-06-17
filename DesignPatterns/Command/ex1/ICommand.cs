namespace DesignPatterns.Command.ex1;

public interface ICommand
{
    void Execute();
    void Undo();
    string Description { get; }
}