namespace DesignPatterns.ChainOfResponsibility.ex1;

public interface IHandler
{
    IHandler SetNext(IHandler next);
    void HandleRequest(ProductData data);
}