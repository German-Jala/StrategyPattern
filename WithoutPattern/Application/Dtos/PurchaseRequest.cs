using WithoutPattern.Domain.Enum;

namespace WithoutPattern.Application.Dtos
{
    public record PurchaseRequest(decimal Amount, PaymentMethod PaymentMethod);
}
