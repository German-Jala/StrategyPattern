using StrategyPattern.Domain.Enum;
using StrategyPattern.Domain.Ports;

namespace StrategyPattern.Infrastructure.Payments
{
    public static class PaymentAdapterFactory
    {
        public static IPaymentProcessorPort GetAdapter(PaymentMethod method)
        {
            return method switch
            {
                PaymentMethod.CreditCard => new CreditCardAdapter(),
                PaymentMethod.PayPal => new PayPalAdapter(),
                PaymentMethod.GooglePay => new GooglePayAdapter(),
                // PaymentMethod.Crypto => new CryptoAdapter(),
                _ => throw new ArgumentException($"El método de pago '{method}' no está soportado en nuestro sistema.")
            };
        }
    }
}
