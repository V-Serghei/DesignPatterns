namespace DesignPatterns.Memento.ex1;

public class TextEditorMemento
{
    // State is private but accessible through properties
    private string Text { get; }
    private int CursorPosition { get; }

    // Constructor captures the originator's state
    public TextEditorMemento(string text, int cursorPosition)
    {
        Text = text;
        CursorPosition = cursorPosition;
    }

    // Only the Originator can access the full state
    // (friend relationship in C#)
    internal string GetText() => Text;
    internal int GetCursorPosition() => CursorPosition;
}