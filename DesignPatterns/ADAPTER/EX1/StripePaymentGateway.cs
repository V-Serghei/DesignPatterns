using DesignPatterns.ADAPTER.EX1.model;

namespace DesignPatterns.ADAPTER.EX1;

public class StripePaymentGateway
{
    public StripeChargeResponse CreateCharge(StripeChargeRequest request)
    {
        // Simulate Stripe API call
        Console.WriteLine($"Stripe: Charging {request.AmountInCents/100.0m} {request.CurrencyCode} " +
                          $"to token {request.SourceToken}");
            
        return new StripeChargeResponse
        {
            Id = $"ch_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 24)}",
            Paid = true,
            Status = "succeeded"
        };
    }
        
    public void RefundCharge(string chargeId)
    {
        Console.WriteLine($"Stripe: Refunding charge {chargeId}");
    }
}