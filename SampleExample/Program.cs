using static SampleExample.Strategies;

namespace SampleExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BIENVENIDO A LA TIENDA DE CONSOLA ===");
            Console.Write("Ingrese el monto a pagar: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Monto inválido.");
                return;
            }

            Console.WriteLine("\nSeleccione su método de pago:");
            Console.WriteLine("1 - Tarjeta de Crédito");
            Console.WriteLine("2 - PayPal");
            Console.WriteLine("3 - Google Pay");
            Console.Write("Opción: ");
            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Opción no válida.");
                return;
            }

            IPaymentStrategy selectedStrategy = option switch
            {
                1 => new CreditCardStrategy(),
                2 => new PayPalStrategy(),
                3 => new GooglePayStrategy(),
                4=> new CryptoStrategy(),
                _ => null
            };

            if (selectedStrategy == null)
            {
                Console.WriteLine("Opción de pago no válida. Abortando.");
                return;
            }

            PaymentService.ExecuteOrder(amount, selectedStrategy);

            Console.WriteLine("\n=== FIN DEL PROCESO ===");
        }
    }
}
