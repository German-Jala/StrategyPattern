using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Application.Dtos;
using StrategyPattern.Application.UseCases;
using StrategyPattern.Infrastructure.Payments;

namespace StrategyPattern.Infrastructure.Adapters.Controllers
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


        [HttpPost]
        public IActionResult Index([FromBody] PurchaseRequest request)
        {
            try
            {
                var selectedAdapter = PaymentAdapterFactory.GetAdapter(request.PaymentMethod);
                bool isSuccess = _processOrderUseCase.Execute(request.Amount, selectedAdapter);
                return isSuccess ? Ok(new { Message = "¡Éxito!" }) : BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
