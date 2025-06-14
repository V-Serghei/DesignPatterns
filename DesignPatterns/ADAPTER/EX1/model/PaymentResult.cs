namespace DesignPatterns.ADAPTER.EX1.model;

public class PaymentResult
{
    public bool Success { get; set; }
    public string TransactionId { get; set; }
    public string Status { get; set; }
    public string ErrorMessage { get; set; }
}