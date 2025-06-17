namespace DesignPatterns.ChainOfResponsibility.ex1;

public class DatabaseHandler: IHandler
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
        Console.WriteLine("DatabaseHandler: Сохранен товар " + data.Name + " в базе данных");
        if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(data); // Передача дальше
        }
    }
}