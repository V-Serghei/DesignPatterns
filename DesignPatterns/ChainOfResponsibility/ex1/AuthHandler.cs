namespace DesignPatterns.ChainOfResponsibility.ex1;

public class AuthHandler: IHandler
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
        if (data.IsAuthenticated)
        {
            Console.WriteLine("AuthHandler: Аутентификация прошла успешно для товара - " + data.Name);
            if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(data); // Передача дальше
            }
        }
        else
        {
            Console.WriteLine("AuthHandler: Аутентификация провалена для товара - " + data.Name + ", цепочка прервана");
        }
    }
}