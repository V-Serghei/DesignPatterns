namespace DesignPatterns.Decorator.ex1;

public class Payment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public Customer Customer { get; set; }
    public PaymentStatus Status { get; set; } = PaymentStatus.New;
}