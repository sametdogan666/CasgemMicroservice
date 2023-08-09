namespace CasgemMicroservice.Services.Basket.DTOs;

public class BasketItemDto
{
    public int Quantity { get; set; }
    public string? ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }

}