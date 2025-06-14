using DesignPatterns.ADAPTER.EX1;
using DesignPatterns.ADAPTER.EX1.model;

namespace DesignPatterns.Client.ADAPTER;

public class ClientAdapter
{
    public void Run()
    {
        // Client code using the Target interface
        Console.WriteLine("Processing payment with our standard payment processor:");
        IPaymentProcessor standardProcessor = new StandardPaymentProcessor();
        ProcessPayment(standardProcessor, 99.99m, "USD", "1234-5678-9012-3456");

        Console.WriteLine("\n--------------------------\n");

        // The client wants to use a third-party payment gateway (Adaptee)
        Console.WriteLine("Processing payment with third-party payment gateway through adapter:");

        // Create the adaptee
        var stripeGateway = new StripePaymentGateway();

        // Create the adapter and pass the adaptee
        IPaymentProcessor stripeAdapter = new StripePaymentAdapter(stripeGateway);

        // Use the adapter with the same client code
        ProcessPayment(stripeAdapter, 149.99m, "EUR", "9876-5432-1098-7654");

        Console.WriteLine("\n--------------------------\n");

        // Another third-party gateway
        Console.WriteLine("Processing payment with PayPal gateway through adapter:");
        IPaymentProcessor paypalAdapter = new PayPalPaymentAdapter("merchant@example.com", "apiKey123");
        ProcessPayment(paypalAdapter, 75.50m, "GBP", "4321-8765-1234-5678");
    }

    // Client code that works with the Target interface
    private static void ProcessPayment(IPaymentProcessor processor, decimal amount, string currency, string cardNumber)
    {
        var result = processor.ProcessPayment(new PaymentDetails
        {
            Amount = amount,
            Currency = currency,
            CardNumber = cardNumber,
            CardExpiryDate = "12/25",
            CardCvv = "123"
        });

        Console.WriteLine($"Payment {(result.Success ? "succeeded" : "failed")}: {result.TransactionId}");
        Console.WriteLine($"Status: {result.Status}");

        if (!result.Success) Console.WriteLine($"Error: {result.ErrorMessage}");
    }
}