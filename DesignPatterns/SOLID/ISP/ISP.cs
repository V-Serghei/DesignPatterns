namespace DesignPatterns.SOLID.ISP;

public class ISP
{
    interface IIPayment
    {
        void ProcessPayment(decimal amount);
        void verifyPaymentCode();
        void sendPaymentNotificationSms();
        
    }
}