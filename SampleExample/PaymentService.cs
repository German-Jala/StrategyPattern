using System;
using System.Collections.Generic;
using System.Text;
using static SampleExample.Strategies;

namespace SampleExample
{
    public class PaymentService
    {
        public static void ExecuteOrder(decimal amount, IPaymentStrategy strategy)
        {
            if (amount <= 0)
            {
                Console.WriteLine("\n[ERROR SERVICIO] El monto debe ser mayor a cero.");
                return;
            }

            Console.WriteLine($"\n[SERVICIO] Iniciando auditoría interna de la orden por ${amount}...");
            Console.WriteLine("[SERVICIO] Stock verificado. Delegando el pago a la estrategia...");

            strategy.Process(amount);

            Console.WriteLine("[SERVICIO] Orden marcada como COMPLETADA en el sistema.");
        }
    }
}
