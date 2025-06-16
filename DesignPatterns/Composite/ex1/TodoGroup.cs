namespace DesignPatterns.Composite.ex1;

public class TaskGroup : TodoItem
{
    private List<TodoItem> _children = new List<TodoItem>();
    private int _managementHours; // Дополнительные часы на управление группой
    
    public TaskGroup(string title, string description = "", int managementHours = 0, 
                     DateTime? dueDate = null) 
        : base(title, description, dueDate)
    {
        _managementHours = managementHours;
    }
    
    // Реализация методов управления потомками
    public override void Add(TodoItem item)
    {
        _children.Add(item);
        item.Parent = this;
    }
    
    public override void Remove(TodoItem item)
    {
        _children.Remove(item);
        item.Parent = null;
    }
    
    public override TodoItem GetChild(int index)
    {
        if (index >= 0 && index < _children.Count)
            return _children[index];
            
        return null;
    }
    
    public override bool IsComposite()
    {
        return true;
    }
    
    // Получить все подзадачи
    public IReadOnlyList<TodoItem> Children => _children.AsReadOnly();
    
    // Реализация основных операций
    public override bool IsCompleted()
    {
        if (_children.Count == 0)
            return false;
            
        // Группа задач считается выполненной, если все подзадачи выполнены
        return _children.All(task => task.IsCompleted());
    }
    
    public override void SetCompleted(bool completed)
    {
        // Устанавливаем статус для всех подзадач
        foreach (var task in _children)
        {
            task.SetCompleted(completed);
        }
    }
    
    public override int GetCompletionPercentage()
    {
        if (_children.Count == 0)
            return 0;
            
        // Вычисляем средневзвешенный процент выполнения на основе оценки времени
        int totalHours = _children.Sum(task => task.GetEstimatedHours());
        
        if (totalHours == 0)
            return 0;
            
        double weightedCompletion = _children.Sum(task => 
            (double)task.GetCompletionPercentage() * task.GetEstimatedHours() / totalHours);
            
        return (int)Math.Round(weightedCompletion);
    }
    
    public override int GetEstimatedHours()
    {
        // Общая оценка времени включает время на все подзадачи + время на управление
        return _children.Sum(task => task.GetEstimatedHours()) + _managementHours;
    }
    
    public override void Display(int depth = 0)
    {
        string completionStatus = IsCompleted() ? "✓" : "□";
        string percentage = $"{GetCompletionPercentage()}%";
        string hours = $"{GetEstimatedHours()} ч.";
        string dueDateInfo = _dueDate == DateTime.MaxValue ? "" : $", до {_dueDate.ToShortDateString()}";
        
        Console.WriteLine($"{GetIndent(depth)}{completionStatus} {_title} [{percentage}] ({hours}{dueDateInfo})");
        
        if (!string.IsNullOrEmpty(_description))
        {
            Console.WriteLine($"{GetIndent(depth + 2)}{_description}");
        }
        
        // Выводим все подзадачи с увеличенным отступом
        foreach (var task in _children)
        {
            task.Display(depth + 1);
        }
    }
    
    public override List<TodoItem> FindOverdueTasks(DateTime currentDate)
    {
        List<TodoItem> result = new List<TodoItem>();
        
        // Проверяем саму группу задач (если у неё установлен срок)
        if (!IsCompleted() && _dueDate < currentDate)
        {
            result.Add(this);
        }
        
        // Проверяем все подзадачи
        foreach (var task in _children)
        {
            result.AddRange(task.FindOverdueTasks(currentDate));
        }
        
        return result;
    }
    
    // Дополнительные методы для работы с группами задач
    
    // Поиск задач по заголовку
    public List<TodoItem> FindByTitle(string searchText, bool caseSensitive = false)
    {
        List<TodoItem> result = new List<TodoItem>();
        StringComparison comparison = caseSensitive ? 
            StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
        
        if (_title.Contains(searchText, comparison))
        {
            result.Add(this);
        }
        
        foreach (var task in _children)
        {
            if (task is TaskGroup taskGroup)
            {
                result.AddRange(taskGroup.FindByTitle(searchText, caseSensitive));
            }
            else if (task.Title.Contains(searchText, comparison))
            {
                result.Add(task);
            }
        }
        
        return result;
    }
    
    // Фильтрация задач по разным критериям
    public List<TodoItem> FilterTasks(Func<TodoItem, bool> predicate)
    {
        List<TodoItem> result = new List<TodoItem>();
        
        foreach (var task in _children)
        {
            if (predicate(task))
            {
                result.Add(task);
            }
            
                if (task is TaskGroup taskGroup)
                {
                    result.AddRange(taskGroup.FilterTasks(predicate));
                }
            }
            
            return result;
        }
    }
    