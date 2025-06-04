using DesignPatterns.FactoryMethod.Ex2.abstracts;

namespace DesignPatterns.FactoryMethod.Ex2.concrete;

public class MailSend: ISenderType

{
    public void Send(string message)
    {
        Console.WriteLine($"Отправка сообщения по электронной почте: {message}");
    }

    public void Close()
    {
        Console.WriteLine("Закрытие соединения с почтовым сервером.");
    }
}