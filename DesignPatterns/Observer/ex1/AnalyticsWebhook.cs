namespace DesignPatterns.Observer.ex1;

public class AnalyticsWebhook: IContentObserver
{
    private string _articleStatus;
    private ContentManager _contentManager;
    
    public AnalyticsWebhook(ContentManager contentManager)
    {
        _contentManager = contentManager;
        _contentManager.Attach(this);
    }

    public void Update()
    {
        _articleStatus = _contentManager.GetState();
        // Логика: Отправка HTTP-запроса в Google Analytics
        Console.WriteLine("Вебхук отправлен в аналитику: Статья - " + _articleStatus);
    }
}