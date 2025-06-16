namespace DesignPatterns.Decorator.ex1;

public interface IPaymentProcessor
{
    void ProcessPayment(Payment payment);
    string GetDescription();
}