using DesignPatterns.FactoryMethod.Ex2.abstracts;

namespace DesignPatterns.FactoryMethod.Ex2.concrete;

public class SmsSenderType: ISenderType
{
    public void Send(string message)
    {
        Console.WriteLine($"Отправка SMS сообщения: {message}");
    }

    public void Close()
    {
        Console.WriteLine("Закрытие соединения с SMS сервером.");
    }
}