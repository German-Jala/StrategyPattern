using StrategyPattern.Domain.Enum;

namespace StrategyPattern.Application.Dtos
{
    public record PurchaseRequest(decimal Amount, PaymentMethod PaymentMethod);
}
