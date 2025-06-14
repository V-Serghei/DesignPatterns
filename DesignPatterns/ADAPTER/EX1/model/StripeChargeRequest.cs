namespace DesignPatterns.ADAPTER.EX1.model;

public class StripeChargeRequest
{
    public long AmountInCents { get; set; }
    public string CurrencyCode { get; set; }
    public string SourceToken { get; set; }
    public Dictionary<string, string> Metadata { get; set; }
}