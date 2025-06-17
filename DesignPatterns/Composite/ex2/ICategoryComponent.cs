namespace DesignPatterns.Composite.ex2;

public interface ICategoryComponent
{
    void Display(int depth);           // Отобразить категорию с учетом уровня вложенности
    void Add(ICategoryComponent category); // Добавить подкатегорию
    void Remove(ICategoryComponent category); // Удалить подкатегорию
    ICategoryComponent GetChild(int index); // Получить подкатегорию по индексу
    string GetName();
}