namespace CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;

public class OrderDetail
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    public int OrderingId { get; set; }
    public Ordering? Order { get; set; }

}