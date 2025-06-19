using DesignPatterns.ChainOfResponsibility.ex1;

namespace DesignPatterns.Client.ChainOfResponsibility;

public class ChainOfResponsibilityClient
{
    public void Run()
    {
        // Настройка цепочки через fluent-интерфейс
        IHandler chain = new LogHandler()
            .SetNext(new AuthHandler())
            .SetNext(new AddProductHandler())
            .SetNext(new DatabaseHandler())
            .SetNext(new LogHandler());
        

        // Тестовый сценарий 1: Успешная обработка
        Console.WriteLine("\n=== Успешная обработка ===");
        ProductData validProduct = new ProductData { Name = "Книга", Price = 29.99m, IsAuthenticated = true, IsValid = true };
        chain.HandleRequest(validProduct);

        // Тестовый сценарий 2: Провал аутентификации
        Console.WriteLine("\n=== Провал аутентификации ===");
        ProductData unauthProduct = new ProductData { Name = "Футболка", Price = 19.99m, IsAuthenticated = false, IsValid = true };
        chain.HandleRequest(unauthProduct);

        // Тестовый сценарий 3: Неверные данные
        Console.WriteLine("\n=== Неверные данные ===");
        ProductData invalidProduct = new ProductData { Name = "Шапка", Price = -5m, IsAuthenticated = true, IsValid = false };
        chain.HandleRequest(invalidProduct);
    }
    
}