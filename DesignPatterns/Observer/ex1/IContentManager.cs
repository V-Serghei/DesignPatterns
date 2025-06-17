namespace DesignPatterns.Observer.ex1;

public interface IContentManager
{
    void Attach(IContentObserver observer);    // Добавить наблюдателя
    void Detach(IContentObserver observer);    // Удалить наблюдателя
    void Notify();// Оповестить всех наблюдателей
}