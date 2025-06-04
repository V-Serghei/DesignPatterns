namespace DesignPatterns.FactoryMethod.Ex2.abstracts;

public interface ISenderType
{
    void Send(string message);
    void Close();
}