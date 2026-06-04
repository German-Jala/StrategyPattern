using StrategyPattern.Domain.Ports;

namespace StrategyPattern.Infrastructure.Payments
{
    public class PayPalAdapter : IPaymentProcessorPort
    {
        public bool Process(decimal amount)
        {
            Console.WriteLine($"[Infraestructura - PayPal] Generando orden de pago en la API REST de PayPal por ${amount}...");
            Console.WriteLine($"[Infraestructura - PayPal] Obteniendo token de redirección de aprobación...");

            bool isOrderCreated = true;

            if (isOrderCreated)
            {
                Console.WriteLine("[Infraestructura - PayPal] Token generado con éxito. Listo para la redirección.");
                return true;
            }

            return false;

        }
    }
}
