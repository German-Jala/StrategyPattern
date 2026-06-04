namespace StrategyPattern.Domain.Ports
{
    public interface IPaymentProcessorPort
    {
        bool Process(decimal amount);
    }
}
