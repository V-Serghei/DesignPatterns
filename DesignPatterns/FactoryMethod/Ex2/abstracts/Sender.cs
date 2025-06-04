namespace DesignPatterns.FactoryMethod.Ex2.abstracts;

public abstract class Sender
{
    public string Message { get; }
    
    public Sender(string message)
    {
        Message = message;
    }
    
    protected abstract ISenderType CreateSender();
    
    
    public void Send()
    {
        var sender = CreateSender();
        sender.Send(Message);
        sender.Close();
    }
    
}