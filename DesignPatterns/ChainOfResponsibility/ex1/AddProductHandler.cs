namespace DesignPatterns.ChainOfResponsibility.ex1;

public class AddProductHandler: IHandler
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
        if (data.IsValid)
        {
            Console.WriteLine("AddProductHandler: Добавлен новый товар - " + data.Name + ", Цена: " + data.Price);
            if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(data); // Передача дальше
            }
        }
        else
        {
            Console.WriteLine("AddProductHandler: Товар " + data.Name + " невалиден, цепочка прервана");
        }
    }
}