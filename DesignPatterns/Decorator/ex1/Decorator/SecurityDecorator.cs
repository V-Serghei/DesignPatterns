namespace DesignPatterns.Decorator.ex1;

public class SecurityDecorator : PaymentProcessorDecorator
{
    private readonly IFraudDetectionService _fraudDetectionService;

    public SecurityDecorator(IPaymentProcessor component, IFraudDetectionService fraudDetectionService) 
        : base(component)
    {
        _fraudDetectionService = fraudDetectionService;
    }

    public override void ProcessPayment(Payment payment)
    {
        // Выполняем проверку безопасности перед обработкой платежа
        bool isSafe = _fraudDetectionService.CheckForFraud(payment);
            
        if (!isSafe)
        {
            payment.Status = PaymentStatus.Blocked;
            Console.WriteLine($"❌ Платеж {payment.Id} заблокирован из-за подозрительной активности!");
            return;
        }
            
        // Если проверка пройдена, вызываем метод базового компонента
        _component.ProcessPayment(payment);
    }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Проверка безопасности";
    }
}