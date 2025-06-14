using DesignPatterns.ADAPTER.EX1.model;

namespace DesignPatterns.ADAPTER.EX1;

public class PayPalPaymentAdapter: IPaymentProcessor
{
    private readonly string _merchantEmail;
    private readonly string _apiKey;
        
    public PayPalPaymentAdapter(string merchantEmail, string apiKey)
    {
        _merchantEmail = merchantEmail;
        _apiKey = apiKey;
    }
        
    public PaymentResult ProcessPayment(PaymentDetails paymentDetails)
    {
        // Simulate PayPal payment processing
        Console.WriteLine($"PayPal: Processing {paymentDetails.Amount} {paymentDetails.Currency} " +
                          $"for merchant {_merchantEmail}");
            
        // In a real implementation, this would call PayPal API
        string transactionId = $"PAY-{Guid.NewGuid().ToString().Substring(0, 17)}";
            
        return new PaymentResult
        {
            Success = true,
            TransactionId = transactionId,
            Status = "Completed"
        };
    }
        
    public void RefundPayment(string transactionId)
    {
        Console.WriteLine($"PayPal: Refunding transaction {transactionId} for merchant {_merchantEmail}");
    }
}
