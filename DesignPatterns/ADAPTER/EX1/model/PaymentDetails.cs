namespace DesignPatterns.ADAPTER.EX1.model;

public class PaymentDetails
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string CardNumber { get; set; }
    public string CardExpiryDate { get; set; }
    public string CardCvv { get; set; }
}