namespace DesignPatterns.ChainOfResponsibility.ex1;

public class LogHandler: IHandler
{
    private IHandler _nextHandler;

   
    public IHandler SetNext(IHandler next)
    {
        if (_nextHandler == null)
        {
            _nextHandler = next;
        }
        else
        {
            _nextHandler.SetNext(next);
        }
        return this;
    }

    public void HandleRequest(ProductData data)
    {
        Console.WriteLine("LogHandler: Логирование входящих данных - Название: " + data.Name + ", Цена: " + data.Price);
        if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(data); // Передача дальше
        }
    }
}