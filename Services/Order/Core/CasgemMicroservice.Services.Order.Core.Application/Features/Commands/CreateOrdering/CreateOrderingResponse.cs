namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateOrdering;

public class CreateOrderingResponse
{
    public string? UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}