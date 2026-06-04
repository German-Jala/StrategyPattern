using StrategyPattern.Domain.Ports;

namespace StrategyPattern.Infrastructure.Payments
{
    public class GooglePayAdapter : IPaymentProcessorPort
    {
        public bool Process(decimal amount)
        {
            Console.WriteLine($"[Infraestructura - Google Pay] Validando token criptográfico de Google...");
            Console.WriteLine($"[Infraestructura - Google Pay] Procesando cargo autorizado por ${amount}...");

            bool isTokenValid = true;

            if (isTokenValid)
            {
                Console.WriteLine("[Infraestructura - Google Pay] Pago procesado y confirmado con éxito.");
                return true;
            }

            Console.WriteLine("[Infraestructura - Google Pay] Error: Token de Google Pay inválido o expirado.");
            return false;
        }
    }
}
