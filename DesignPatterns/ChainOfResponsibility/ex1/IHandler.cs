namespace DesignPatterns.ChainOfResponsibility.ex1;

public interface IHandler
{
    IHandler SetNext(IHandler next);    // Установить следующего обработчика
    void HandleRequest(ProductData data);
}