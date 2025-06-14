using DesignPatterns.ADAPTER.EX1.model;

namespace DesignPatterns.ADAPTER.EX1;

public interface IPaymentProcessor
{
    PaymentResult ProcessPayment(PaymentDetails paymentDetails);
    void RefundPayment(string transactionId);
}