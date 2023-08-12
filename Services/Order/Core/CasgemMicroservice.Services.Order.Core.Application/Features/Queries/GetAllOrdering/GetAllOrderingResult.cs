namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllOrdering;

public class GetAllOrderingResult
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}