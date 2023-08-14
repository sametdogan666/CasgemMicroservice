namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdOrderDetail;

public class GetByIdOrderDetailResult
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    public int OrderingId { get; set; }
}