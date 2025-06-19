using DesignPatterns.ADAPTER.EX1.model;

namespace DesignPatterns.ADAPTER.EX1;

public class StandardPaymentProcessor: IPaymentProcessor
{
    public PaymentResult ProcessPayment(PaymentDetails paymentDetails)
    {
        // Simulate payment processing with our standard processor
        Console.WriteLine($"Processing {paymentDetails.Amount} {paymentDetails.Currency} " +
                          $"using card ending with {paymentDetails.CardNumber.Substring(paymentDetails.CardNumber.Length - 4)}");
            
        return new PaymentResult
        {
            Success = true,
            TransactionId = $"STD-{Guid.NewGuid().ToString().Substring(0, 8)}",
            Status = "Completed"
        };
    }
        
    public void RefundPayment(string transactionId)
    {
        
        Console.WriteLine($"Refunding payment with transaction ID: {transactionId}");
    }
}