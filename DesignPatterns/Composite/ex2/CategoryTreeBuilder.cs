namespace DesignPatterns.Composite.ex2;

public class CategoryTreeBuilder
{
    // Симуляция получения данных из базы данных
    private List<(string Name, string? ParentName, string? Description)> FetchFromDatabase()
    {
        return new List<(string, string?, string?)>
        {
            ("Электроника", null, null),
            ("Смартфоны", "Электроника", null),
            ("iPhone", "Смартфоны", "Флагманские модели Apple"),
            ("Аксессуары", "Электроника", null),
            ("Чехлы", "Аксессуары", "Защита для смартфонов")
        };
    }

    // Построение дерева категорий
    public ICategoryComponent BuildCategoryTree()
    {
        var data = FetchFromDatabase();
        var root = new CompositeCategory("Каталог"); // Корневой узел
        var categoryMap = new Dictionary<string, ICategoryComponent>();

        // Создание всех категорий и их добавление в карту
        foreach (var (name, parentName, description) in data)
        {
            if (description != null)
            {
                categoryMap[name] = new LeafCategory(name, description);
            }
            else
            {
                categoryMap[name] = new CompositeCategory(name);
            }
        }

        // Построение иерархии
        foreach (var (name, parentName, _) in data)
        {
            var category = categoryMap[name];
            if (parentName == null)
            {
                root.Add(category); // Корневые категории
            }
            else
            {
                var parent = categoryMap[parentName];
                if (parent is CompositeCategory composite)
                {
                    composite.Add(category);
                }
            }
        }

        return root;
    }

    
}