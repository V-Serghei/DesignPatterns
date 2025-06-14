namespace DesignPatterns.ADAPTER.EX1.model;

public class StripeChargeResponse
{
    public string Id { get; set; }
    public bool Paid { get; set; }
    public string Status { get; set; }
    public string FailureMessage { get; set; }
}