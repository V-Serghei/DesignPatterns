namespace DesignPatterns.Decorator.ex1;

public class NotificationDecorator : PaymentProcessorDecorator
{
    private readonly INotificationService _notificationService;

    public NotificationDecorator(IPaymentProcessor component, INotificationService notificationService) 
        : base(component)
    {
        _notificationService = notificationService;
    }

    public override void ProcessPayment(Payment payment)
    {
        // Вызываем метод базового компонента
        _component.ProcessPayment(payment);
            
        // Отправляем уведомление после обработки платежа
        if (payment.Status == PaymentStatus.Processed)
        {
            _notificationService.SendNotification(
                payment.Customer.Email,
                $"Платеж на сумму {payment.Amount:C} успешно обработан",
                $"Уважаемый {payment.Customer.Name}, ваш платеж #{payment.Id} на сумму {payment.Amount:C} " +
                $"с помощью {payment.PaymentMethod} был успешно обработан."
            );
        }
        else if (payment.Status == PaymentStatus.Failed || payment.Status == PaymentStatus.Blocked)
        {
            _notificationService.SendNotification(
                payment.Customer.Email,
                $"Проблема с платежом на сумму {payment.Amount:C}",
                $"Уважаемый {payment.Customer.Name}, к сожалению, возникла проблема с вашим платежом #{payment.Id}. " +
                $"Пожалуйста, свяжитесь с нашей службой поддержки."
            );
        }
    }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Уведомления";
    }
}