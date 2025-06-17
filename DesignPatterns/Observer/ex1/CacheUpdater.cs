namespace DesignPatterns.Observer.ex1;

public class CacheUpdater: IContentObserver
{
    private string _articleStatus;
    private ContentManager _contentManager;
    
    public CacheUpdater(ContentManager contentManager)
    {
        _contentManager = contentManager;
        _contentManager.Attach(this);
    }

    public void Update()
    {
        _articleStatus = _contentManager.GetState();
        // Логика: Обновление кэша (например, Redis)
        Console.WriteLine("Кэш обновлен: Статья - " + _articleStatus);
    }
}