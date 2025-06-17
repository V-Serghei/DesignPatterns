namespace DesignPatterns.Memento.ex1;

public class History
{
    private readonly Stack<TextEditorMemento> _undoStack = new Stack<TextEditorMemento>();
    private readonly Stack<TextEditorMemento> _redoStack = new Stack<TextEditorMemento>();

    // Add a state to history
    public void Push(TextEditorMemento memento)
    {
        _undoStack.Push(memento);
        // Clear redo stack when a new action is performed
        _redoStack.Clear();
    }

    // Get the previous state (undo)
    public TextEditorMemento Undo()
    {
        if (_undoStack.Count <= 1)
        {
            Console.WriteLine("Nothing to undo");
            return null;
        }

        var current = _undoStack.Pop();
        _redoStack.Push(current);
        return _undoStack.Peek();
    }

    // Get the next state (redo)
    public TextEditorMemento Redo()
    {
        if (_redoStack.Count == 0)
        {
            Console.WriteLine("Nothing to redo");
            return null;
        }

        var memento = _redoStack.Pop();
        _undoStack.Push(memento);
        return memento;
    }
}