namespace DesignPatterns.Observer.ex1;

public class EmailNotifier: IContentObserver
{
    private string _articleStatus;
    private ContentManager _contentManager;
    
    public EmailNotifier(ContentManager contentManager)
    {
        _contentManager = contentManager;
        _contentManager.Attach(this);
    }

    public void Update()
    {
        _articleStatus = _contentManager.GetState();
        // Логика: Отправка email через SMTP (например, SendGrid)
        Console.WriteLine("Отправлено email уведомление: Статья - " + _articleStatus);
    }
}