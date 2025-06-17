using DesignPatterns.Observer.ex1;

namespace DesignPatterns.Client.Observer;

public class ObserverClient
{
    public void Run()
    {
        ContentManager contentManager = new ContentManager();

        // Создаем наблюдателей
        EmailNotifier emailNotifier = new EmailNotifier(contentManager);
        CacheUpdater cacheUpdater = new CacheUpdater(contentManager);
        AnalyticsWebhook analyticsWebhook = new AnalyticsWebhook(contentManager);
        AdminUIUpdater adminUIUpdater = new AdminUIUpdater(contentManager);

        // Регистрируем наблюдателей
        contentManager.Attach(emailNotifier);
        contentManager.Attach(cacheUpdater);
        contentManager.Attach(analyticsWebhook);
        contentManager.Attach(adminUIUpdater);

        // Публикуем статью (изменяем состояние)
        contentManager.PublishArticle("Новая статья о технологиях");

        // Удаляем один наблюдатель
        contentManager.Detach(analyticsWebhook);

        // Публикуем еще одну статью
        contentManager.PublishArticle("Обновление статьи");
    }
}