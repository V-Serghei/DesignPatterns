using DesignPatterns.FactoryMethod.Ex2.abstracts;

namespace DesignPatterns.FactoryMethod.Ex2.concrete;

public class MailSenderCreator: Sender
{
    public MailSenderCreator(string message) : base(message) { }

    protected override ISenderType CreateSender()
    {
        return new MailSend();
    }
}