using DesignPatterns.Decorator.ex1;

namespace DesignPatterns.Client.Decorator;

public class ClinentDecorator
{
    public void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            // Создаем службы
            var logger = new ConsoleLogger();
            var fraudDetection = new SimpleFraudDetectionService();
            var notificationService = new EmailNotificationService();
            var analyticsService = new SimpleAnalyticsService();
            
            // Создаем базовый процессор платежей
            IPaymentProcessor basicProcessor = new BasicPaymentProcessor();
            
            // Создаем платежи для обработки
            var payment1 = new Payment
            {
                Amount = 99.99m,
                PaymentMethod = "Кредитная карта",
                Customer = new Customer { Name = "Иван Петров", Email = "ivan@example.com" }
            };
            
            var payment2 = new Payment
            {
                Amount = 15000.00m, // Большая сумма для проверки безопасности
                PaymentMethod = "Банковский перевод",
                Customer = new Customer { Name = "Мария Сидорова", Email = "maria@example.com" }
            };

            Console.WriteLine("=== Пример 1: Базовая обработка ===");
            basicProcessor.ProcessPayment(payment1);
            Console.WriteLine($"Описание процессора: {basicProcessor.GetDescription()}");
            Console.WriteLine();

            // Пример 2: Добавляем логирование
            Console.WriteLine("=== Пример 2: Базовая обработка + Логирование ===");
            IPaymentProcessor loggingProcessor = new LoggingDecorator(basicProcessor, logger);
            loggingProcessor.ProcessPayment(payment1);
            Console.WriteLine($"Описание процессора: {loggingProcessor.GetDescription()}");
            Console.WriteLine();

            // Пример 3: Добавляем логирование + безопасность
            Console.WriteLine("=== Пример 3: Базовая обработка + Логирование + Безопасность ===");
            IPaymentProcessor secureLoggingProcessor = 
                new SecurityDecorator(
                    new LoggingDecorator(basicProcessor, logger), 
                    fraudDetection);
            secureLoggingProcessor.ProcessPayment(payment2); // Должен быть заблокирован
            Console.WriteLine($"Описание процессора: {secureLoggingProcessor.GetDescription()}");
            Console.WriteLine();

            // Пример 4: Полный стек декораторов
            Console.WriteLine("=== Пример 4: Полный стек декораторов ===");
            IPaymentProcessor fullStackProcessor = 
                new AnalyticsDecorator(
                    new NotificationDecorator(
                        new SecurityDecorator(
                            new LoggingDecorator(basicProcessor, logger),
                            fraudDetection),
                        notificationService),
                    analyticsService);
            
            Console.WriteLine("Обработка платежа на небольшую сумму:");
            fullStackProcessor.ProcessPayment(payment1);
            
            Console.WriteLine("\nОбработка платежа на крупную сумму (должен быть заблокирован):");
            fullStackProcessor.ProcessPayment(payment2);
            
            Console.WriteLine($"Описание процессора: {fullStackProcessor.GetDescription()}");
    }
}