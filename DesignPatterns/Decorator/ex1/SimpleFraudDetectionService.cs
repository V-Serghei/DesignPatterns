namespace DesignPatterns.Decorator.ex1;

public class SimpleFraudDetectionService : IFraudDetectionService
{
    public bool CheckForFraud(Payment payment)
    {
        // Простая имитация проверки: блокируем платежи > $10,000
        if (payment.Amount > 10000)
        {
            Console.WriteLine($"🔍 Обнаружена подозрительная активность для платежа {payment.Id}: сумма превышает $10,000");
            return false;
        }
            
        Console.WriteLine($"🔍 Проверка безопасности для платежа {payment.Id} пройдена");
        return true;
    }
}
