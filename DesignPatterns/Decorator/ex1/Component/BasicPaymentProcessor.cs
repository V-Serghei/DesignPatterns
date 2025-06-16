namespace DesignPatterns.Decorator.ex1;

public class BasicPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Payment payment)
    {
        Console.WriteLine($"Выполняется базовая обработка платежа на сумму {payment.Amount:C} для {payment.PaymentMethod}...");
        // Базовая логика обработки платежа
        payment.Status = PaymentStatus.Processed;
    }

    public string GetDescription()
    {
        return "Базовый процессор платежей";
    }
}