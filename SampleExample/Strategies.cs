using System;
using System.Collections.Generic;
using System.Text;

namespace SampleExample
{
    public class Strategies
    {
        public interface IPaymentStrategy
        {
            void Process(decimal amount);
        }

        public class CreditCardStrategy : IPaymentStrategy
        {
            public void Process(decimal amount)
            {
                Console.WriteLine($"\n[STRIPE SDK] Cobrando ${amount} de la tarjeta de crédito...");
                Console.WriteLine("[STRIPE SDK] ¡Transacción autorizada con éxito!");
            }
        }

        public class PayPalStrategy : IPaymentStrategy
        {
            public void Process(decimal amount)
            {
                Console.WriteLine($"\n[PAYPAL API] Redirigiendo al usuario para procesar ${amount}...");
                Console.WriteLine("[PAYPAL API] ¡Pago verificado correctamente!");
            }
        }
        public class GooglePayStrategy : IPaymentStrategy
        {
            public void Process(decimal amount)
            {
                Console.WriteLine($"\n[GooglePay API] Redirigiendo al usuario para procesar ${amount}...");
                Console.WriteLine("[GooglePay API] ¡Pago verificado correctamente!");
            }
        }

        public class CryptoStrategy : IPaymentStrategy
        {
            public void Process(decimal amount)
            {
                Console.WriteLine($"\n[Crypto API] Redirigiendo al usuario para procesar ${amount}...");
                Console.WriteLine("[Crypto API] ¡Pago verificado correctamente!");
            }
        }
    }
}
