namespace DesignPatterns.Memento.ex1;

public class TextEditor
{
    private string _text;
    private int _cursorPosition;

    public TextEditor()
    {
        _text = string.Empty;
        _cursorPosition = 0;
    }

    // Methods to modify state
    public void Type(string text)
    {
        // Insert text at cursor position
        _text = _text.Insert(_cursorPosition, text);
        _cursorPosition += text.Length;
        Console.WriteLine($"Typed: {text}");
        DisplayState();
    }

    public void DeleteText(int length)
    {
        if (_cursorPosition >= length)
        {
            _text = _text.Remove(_cursorPosition - length, length);
            _cursorPosition -= length;
            Console.WriteLine($"Deleted {length} characters");
            DisplayState();
        }
    }

    public void MoveCursor(int position)
    {
        if (position >= 0 && position <= _text.Length)
        {
            _cursorPosition = position;
            Console.WriteLine($"Cursor moved to position {position}");
            DisplayState();
        }
    }

    // Create a memento
    public TextEditorMemento Save()
    {
        Console.WriteLine("Saving state...");
        return new TextEditorMemento(_text, _cursorPosition);
    }

    // Restore from a memento
    public void Restore(TextEditorMemento memento)
    {
        if (memento == null) return;

        _text = memento.GetText();
        _cursorPosition = memento.GetCursorPosition();
            
        Console.WriteLine("State restored");
        DisplayState();
    }

    public void DisplayState()
    {
        Console.WriteLine($"Current text: \"{_text}\"");
        Console.WriteLine($"Cursor position: {_cursorPosition}");
        Console.WriteLine();
    }
}