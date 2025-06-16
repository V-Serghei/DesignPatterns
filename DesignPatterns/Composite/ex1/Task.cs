namespace DesignPatterns.Composite.ex1;

public class SingleTask : TodoItem
{
    private bool _completed;
    private int _estimatedHours;
    private string _priority;
        
    public SingleTask(string title, string description = "", int estimatedHours = 1, 
        string priority = "Medium", DateTime? dueDate = null) 
        : base(title, description, dueDate)
    {
        _completed = false;
        _estimatedHours = estimatedHours;
        _priority = priority;
    }
        
    public string Priority => _priority;
        
    public override bool IsCompleted()
    {
        return _completed;
    }
        
    public override void SetCompleted(bool completed)
    {
        _completed = completed;
    }
        
    public override int GetCompletionPercentage()
    {
        return _completed ? 100 : 0;
    }
        
    public override int GetEstimatedHours()
    {
        return _estimatedHours;
    }
        
    public override void Display(int depth = 0)
    {
        string status = _completed ? "✓" : "□";
        string dueDateInfo = _dueDate == DateTime.MaxValue ? "" : $", до {_dueDate.ToShortDateString()}";
            
        Console.WriteLine($"{GetIndent(depth)}{status} {_title} ({_estimatedHours} ч., {_priority}{dueDateInfo})");
            
        if (!string.IsNullOrEmpty(_description))
        {
            Console.WriteLine($"{GetIndent(depth + 2)}{_description}");
        }
    }
        
    public override List<TodoItem> FindOverdueTasks(DateTime currentDate)
    {
        List<TodoItem> result = new List<TodoItem>();
            
        if (!_completed && _dueDate < currentDate)
        {
            result.Add(this);
        }
            
        return result;
    }
}