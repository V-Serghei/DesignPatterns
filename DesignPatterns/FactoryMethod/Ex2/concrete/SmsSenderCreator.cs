using DesignPatterns.FactoryMethod.Ex2.abstracts;

namespace DesignPatterns.FactoryMethod.Ex2.concrete;

public class SmsSenderCreator: Sender
{
    public SmsSenderCreator(string message) : base(message) { }
    
    
    protected override ISenderType CreateSender()
    {
        return new SmsSenderType();
    }
}