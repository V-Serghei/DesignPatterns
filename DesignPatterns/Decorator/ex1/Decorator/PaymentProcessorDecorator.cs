namespace DesignPatterns.Decorator.ex1;

public abstract class PaymentProcessorDecorator : IPaymentProcessor
{
    protected IPaymentProcessor _component;

    public PaymentProcessorDecorator(IPaymentProcessor component)
    {
        _component = component;
    }

    // Делегируем вызов методов декорируемому объекту
    public virtual void ProcessPayment(Payment payment)
    {
        _component.ProcessPayment(payment);
    }

    public virtual string GetDescription()
    {
        return _component.GetDescription();
    }
}
