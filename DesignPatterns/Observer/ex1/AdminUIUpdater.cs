namespace DesignPatterns.Observer.ex1;

public class AdminUIUpdater: IContentObserver
{
    private string _articleStatus;
    private ContentManager _contentManager;
    
    public AdminUIUpdater(ContentManager contentManager)
    {
        _contentManager = contentManager;
        _contentManager.Attach(this);
    }

    public void Update()
    {
        _articleStatus = _contentManager.GetState();
        // Логика: Обновление DOM в админке (например, через JavaScript)
        Console.WriteLine("Интерфейс админки обновлен: Статья - " + _articleStatus);
    }
}