using DesignPatterns.ADAPTER.EX1.model;

namespace DesignPatterns.ADAPTER.EX1;

public class StripePaymentAdapter: IPaymentProcessor
    {
        private readonly StripePaymentGateway _stripeGateway;
        
        public StripePaymentAdapter(StripePaymentGateway stripeGateway)
        {
            _stripeGateway = stripeGateway;
        }
        
        public PaymentResult ProcessPayment(PaymentDetails paymentDetails)
        {
            // Convert PaymentDetails to StripeChargeRequest
            var stripeRequest = new StripeChargeRequest
            {
                AmountInCents = (long)(paymentDetails.Amount * 100), // Convert to cents
                CurrencyCode = paymentDetails.Currency.ToLower(),
                SourceToken = TokenizeCard(paymentDetails.CardNumber, paymentDetails.CardExpiryDate, paymentDetails.CardCvv),
                Metadata = new Dictionary<string, string>
                {
                    ["card_last4"] = paymentDetails.CardNumber.Substring(paymentDetails.CardNumber.Length - 4)
                }
            };
            
            // Call the adaptee
            var stripeResponse = _stripeGateway.CreateCharge(stripeRequest);
            
            // Convert StripeChargeResponse to PaymentResult
            return new PaymentResult
            {
                Success = stripeResponse.Paid,
                TransactionId = stripeResponse.Id,
                Status = MapStripeStatus(stripeResponse.Status),
                ErrorMessage = stripeResponse.FailureMessage
            };
        }
        
        public void RefundPayment(string transactionId)
        {
            _stripeGateway.RefundCharge(transactionId);
        }
        
        // Helper methods for adaptation
        private string TokenizeCard(string cardNumber, string expiryDate, string cvv)
        {
            // In a real implementation, this would call Stripe API to tokenize the card
            return $"tok_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 24)}";
        }
        
        private string MapStripeStatus(string stripeStatus)
        {
            return stripeStatus switch
            {
                "succeeded" => "Completed",
                "pending" => "Pending",
                "failed" => "Failed",
                _ => "Unknown"
            };
        }
    }