namespace WithoutPattern.Domain.Ports
{
    public interface IPaymentProcessorPort
    {
        bool Process(decimal amount);
    }
}
