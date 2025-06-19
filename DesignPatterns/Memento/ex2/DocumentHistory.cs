namespace DesignPatterns.Memento.ex2;

public class DocumentHistory
{
    
    private Stack<Memento> _history = new Stack<Memento>(); // Стек для истории

    // Добавить состояние в историю
    public void SaveState(Memento memento)
    {
        _history.Push(memento);
        Console.WriteLine("Состояние добавлено в историю.");
    }

    // Получить последнее сохраненное состояние
    public Memento GetPreviousState()
    {
        if (_history.Count > 0)
        {
            Console.WriteLine("Возвращение предыдущего состояния...");
            return _history.Pop();
        }
        Console.WriteLine("История пуста.");
        return null;
    }
}