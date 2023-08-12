namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllOrderDetails;

public class GetAllOrderDetailsResult
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    public int OrderId { get; set; }
}