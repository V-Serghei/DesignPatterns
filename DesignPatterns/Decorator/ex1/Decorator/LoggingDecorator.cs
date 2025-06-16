namespace DesignPatterns.Decorator.ex1;

public class LoggingDecorator : PaymentProcessorDecorator
{
    private readonly ILogger _logger;

    public LoggingDecorator(IPaymentProcessor component, ILogger logger) 
        : base(component)
    {
        _logger = logger;
    }

    public override void ProcessPayment(Payment payment)
    {
        // Логирование до выполнения платежа
        _logger.Log($"НАЧАЛО ПЛАТЕЖА {DateTime.Now}: ID={payment.Id}, Сумма={payment.Amount:C}, Метод={payment.PaymentMethod}");
            
        // Вызываем метод базового компонента
        _component.ProcessPayment(payment);
            
        // Логирование после выполнения платежа
        _logger.Log($"ЗАВЕРШЕНИЕ ПЛАТЕЖА {DateTime.Now}: ID={payment.Id}, Статус={payment.Status}");
    }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Логирование";
    }
}