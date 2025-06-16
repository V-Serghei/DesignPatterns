namespace DesignPatterns.Composite.ex1;

public abstract class TodoItem
{
    protected string _title;
    protected string _description;
    protected DateTime _dueDate;
    protected TodoItem _parent;
    
    // Конструктор
    public TodoItem(string title, string description = "", DateTime? dueDate = null)
    {
        _title = title;
        _description = description;
        _dueDate = dueDate ?? DateTime.MaxValue;
    }

    // Свойства
    public string Title => _title;
    public string Description => _description;
    public DateTime DueDate => _dueDate;

    // Свойство для работы с родительским компонентом
    public TodoItem Parent
    {
        get { return _parent; }
        set { _parent = value; }
    }
    
    // Основные операции, которые должны реализовать все компоненты
    public abstract bool IsCompleted();
    public abstract void SetCompleted(bool completed);
    public abstract int GetCompletionPercentage();
    public abstract int GetEstimatedHours();
    public abstract void Display(int depth = 0);
    public abstract List<TodoItem> FindOverdueTasks(DateTime currentDate);
    
    // Методы для управления потомками с реализацией по умолчанию
    public virtual void Add(TodoItem item)
    {
        throw new NotSupportedException("Добавление не поддерживается для этого типа задачи");
    }
    
    public virtual void Remove(TodoItem item)
    {
        throw new NotSupportedException("Удаление не поддерживается для этого типа задачи");
    }
    
    public virtual TodoItem GetChild(int index)
    {
        throw new NotSupportedException("У этой задачи нет подзадач");
    }
    
    // Метод для определения типа компонента
    public virtual bool IsComposite()
    {
        return false;
    }
    
    // Вспомогательный метод для форматирования отступов
    protected string GetIndent(int depth)
    {
        return new string(' ', depth * 2);
    }
    
    // Получение полного пути задачи
    public string GetTaskPath()
    {
        if (_parent == null)
            return Title;
            
        return $"{_parent.GetTaskPath()} > {Title}";
    }
}