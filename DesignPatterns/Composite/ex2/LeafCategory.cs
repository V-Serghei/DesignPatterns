namespace DesignPatterns.Composite.ex2;

public class LeafCategory: ICategoryComponent
{
    private string _name;
    private string _description;

    public LeafCategory(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Display(int depth)
    {
        string indent = new string(' ', depth * 2);
        Console.WriteLine($"{indent}- {_name}: {_description}");
    }

    public void Add(ICategoryComponent category)
    {
        Console.WriteLine("LeafCategory: Нельзя добавить подкатегорию к конечной категории");
    }

    public void Remove(ICategoryComponent category)
    {
        Console.WriteLine("LeafCategory: Нельзя удалить подкатегорию из конечной категории");
    }

    public ICategoryComponent GetChild(int index)
    {
        return null; // Листовые узлы не имеют детей
    }

    public string GetName()
    {
        return _name;
    }
}