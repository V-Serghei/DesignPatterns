namespace DesignPatterns.Observer.ex1;

public class ContentManager: IContentManager
{
    private List<IContentObserver> _observers = new List<IContentObserver>(); // Список наблюдателей
    private string _articleState;                                           // Состояние статьи

    public void Attach(IContentObserver observer)
    {
        _observers.Add(observer);
        // Логика: Регистрация наблюдателя в системе
    }

    public void Detach(IContentObserver observer)
    {
        _observers.Remove(observer);
        // Логика: Удаление наблюдателя из системы
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }

    // Публикация статьи (изменение состояния)
    public void PublishArticle(string state)
    {
        _articleState = state;
        // Логика: Сохранение статьи в базе данных
        Console.WriteLine($"Статья опубликована: {_articleState}");
        Notify();
    }

    // Получить текущее состояние
    public string GetState()
    {
        return _articleState;
    }
}