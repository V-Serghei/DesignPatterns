namespace DesignPatterns.Memento.ex2;

public class DocumentR
{
    
    private string _content;        // Содержимое документа
    private int _cursorPosition;    // Позиция курсора
    private string _lastModified;   // Время последнего изменения

    // Конструктор
    public DocumentR()
    {
        _content = "";
        _cursorPosition = 0;
        _lastModified = DateTime.Now.ToString();
    }

    // Изменить содержимое
    public void Edit(string newText)
    {
        _content += newText;
        _cursorPosition += newText.Length;
        _lastModified = DateTime.Now.ToString();
        Console.WriteLine($"Документ изменен: {_content}");
    }

    // Сохранить текущее состояние
    public Memento Save()
    {
        Console.WriteLine("Сохранение состояния документа...");
        return new Memento(_content, _cursorPosition, _lastModified);
    }

    // Восстановить состояние из Memento
    public void Restore(Memento memento)
    {
        _content = memento.GetContent();
        _cursorPosition = memento.GetCursorPosition();
        _lastModified = memento.GetLastModified();
        Console.WriteLine("Состояние документа восстановлено.");
    }

    // Показать текущее состояние
    public void Display()
    {
        Console.WriteLine($"Содержимое: {_content}");
        Console.WriteLine($"Позиция курсора: {_cursorPosition}");
        Console.WriteLine($"Последнее изменение: {_lastModified}");
    }
}