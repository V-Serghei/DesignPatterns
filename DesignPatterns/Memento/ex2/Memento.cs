namespace DesignPatterns.Memento.ex2;

public class Memento
{
    private string _content;
    private int _cursorPosition;
    private string _lastModified;

    // Конструктор, доступный только Document
    internal Memento(string content, int cursorPosition, string lastModified)
    {
        _content = content;
        _cursorPosition = cursorPosition;
        _lastModified = lastModified;
    }

    // Методы для доступа к состоянию (только для Document)
    internal string GetContent() => _content;
    internal int GetCursorPosition() => _cursorPosition;
    internal string GetLastModified() => _lastModified;
}