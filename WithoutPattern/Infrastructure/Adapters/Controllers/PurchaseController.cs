using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WithoutPattern.Application.Dtos;
using WithoutPattern.Application.UseCases;
using WithoutPattern.Domain.Enum;

namespace WithoutPattern.Infrastructure.Adapters.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : Controller
    {
        private readonly ProcessOrderUseCase _processOrderUseCase;

        public PurchaseController(ProcessOrderUseCase processOrderUseCase)
        {
            _processOrderUseCase = processOrderUseCase;
        }


        [HttpPost("purchase-no")]
        public IActionResult Purchase([FromBody] PurchaseRequest request)
        {
            if (request.Amount <= 0) return BadRequest(new { Message = "Monto inválido." });
            Console.WriteLine($"[LOG] Iniciando proceso de compra por ${request.Amount}");

            switch (request.PaymentMethod)
            {
                case PaymentMethod.CreditCard:
                    if (string.IsNullOrEmpty(request.Amount.ToString()))
                        return BadRequest(new { Message = "Falta el número de tarjeta." });

                    Console.WriteLine($"[Stripe SDK] Cobrando ${request.Amount} a la tarjeta 7579546546546");
                    Console.WriteLine("[Stripe SDK] Pago Exitoso.");
                    break;

                case PaymentMethod.GooglePay:
                    if (string.IsNullOrEmpty(request.Amount.ToString()))
                        return BadRequest(new { Message = "Falta el email de GooglePay." });

                    Console.WriteLine($"[GooglePay API] Generando orden para 456C6546");
                    Console.WriteLine("[GooglePay API] Redirección exitosa.");
                    break;

                case PaymentMethod.PayPal:
                    if (string.IsNullOrEmpty("4")) return BadRequest(new { Message = "Falta la paypal de destino." });

                    Console.WriteLine($"[Paypal] Generando QR para la wallet 48D665455D");
                    Console.WriteLine("[Paypal] Transacción detectada.");
                    break;

                default:
                    return BadRequest(new { Message = "Método de pago no soportado." });
            }

            // 3. Más lógica de negocio posterior al pago aquí tirada
            Console.WriteLine("[LOG] Orden guardada en la base de datos como COMPLETADA.");

            return Ok(new { Message = "Compra caótica pero exitosa." });
        }
    }
}
