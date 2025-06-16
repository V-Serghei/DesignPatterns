namespace DesignPatterns.Decorator.ex1;

public interface IFraudDetectionService
{
    bool CheckForFraud(Payment payment);
}