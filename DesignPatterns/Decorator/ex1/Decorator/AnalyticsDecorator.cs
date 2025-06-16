namespace DesignPatterns.Decorator.ex1;

public class AnalyticsDecorator : PaymentProcessorDecorator
{
    private readonly IAnalyticsService _analyticsService;

    public AnalyticsDecorator(IPaymentProcessor component, IAnalyticsService analyticsService) 
        : base(component)
    {
        _analyticsService = analyticsService;
    }

    public override void ProcessPayment(Payment payment)
    {
        // Замеряем время выполнения
        var startTime = DateTime.Now;
            
        // Вызываем метод базового компонента
        _component.ProcessPayment(payment);
            
        // Собираем аналитику
        var processingTime = DateTime.Now - startTime;
            
        _analyticsService.TrackEvent("Payment_Processed", new Dictionary<string, string>
        {
            { "PaymentId", payment.Id.ToString() },
            { "Amount", payment.Amount.ToString() },
            { "PaymentMethod", payment.PaymentMethod },
            { "Status", payment.Status.ToString() },
            { "ProcessingTime", processingTime.TotalMilliseconds.ToString() }
        });
    }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Аналитика";
    }
}