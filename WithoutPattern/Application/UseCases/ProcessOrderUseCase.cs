using WithoutPattern.Domain.Ports;

namespace WithoutPattern.Application.UseCases
{
    public class ProcessOrderUseCase
    {
        public bool Execute(
            decimal amount,
            IPaymentProcessorPort paymentProcessor
        )
        {
            if (amount <= 0) throw new ArgumentException("El monto de la orden debe ser mayor a cero.");
            Console.WriteLine($"[Aplicación] Iniciando el caso de uso para una orden de ${amount}...");

            bool isPaymentSuccessful = paymentProcessor.Process(amount);

            if (isPaymentSuccessful)
            {
                Console.WriteLine("[Aplicación] El pago fue aprobado. Registrando orden como COMPLETADA.");
                return true;
            }

            Console.WriteLine("[Aplicación] El pago fue rechazado. La orden no puede completarse.");
            return false;
        }
    }
}
