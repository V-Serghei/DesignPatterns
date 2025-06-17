namespace DesignPatterns.Composite.ex2;

public class CompositeCategory: ICategoryComponent
{
    private string _name;
    private List<ICategoryComponent> _children = new List<ICategoryComponent>();

    public CompositeCategory(string name)
    {
        _name = name;
    }

    public void Display(int depth)
    {
        string indent = new string(' ', depth * 2);
        Console.WriteLine($"{indent}+ {_name}");
        foreach (var child in _children)
        {
            child.Display(depth + 1); // Рекурсивный рендер подкатегорий
        }
    }

    public void Add(ICategoryComponent category)
    {
        _children.Add(category);
        Console.WriteLine($"CompositeCategory: Добавлена подкатегория {category.GetName()} к {_name}");
    }

    public void Remove(ICategoryComponent category)
    {
        _children.Remove(category);
        Console.WriteLine($"CompositeCategory: Удалена подкатегория {category.GetName()} из {_name}");
    }

    public ICategoryComponent GetChild(int index)
    {
        if (index >= 0 && index < _children.Count)
        {
            return _children[index];
        }
        return null;
    }

    public string GetName()
    {
        return _name;
    }
}