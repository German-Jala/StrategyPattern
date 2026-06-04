using StrategyPattern.Domain.Ports;

namespace StrategyPattern.Infrastructure.Payments
{
    public class CreditCardAdapter: IPaymentProcessorPort
    {
        public bool Process(decimal amount)
        {
            Console.WriteLine($"[Infraestructura - Tarjeta] Conectando de forma segura con la pasarela de pagos...");
            Console.WriteLine($"[Infraestructura - Tarjeta] Enviando solicitud de cargo por un monto de ${amount}...");
            bool apiResponse = true;

            if (apiResponse)
            {
                Console.WriteLine("[Infraestructura - Tarjeta] Transacción aprobada por el banco.");
                return true;
            }

            Console.WriteLine("[Infraestructura - Tarjeta] Transacción rechazada: Fondos insuficientes.");
            return false;
        }
    }
}
