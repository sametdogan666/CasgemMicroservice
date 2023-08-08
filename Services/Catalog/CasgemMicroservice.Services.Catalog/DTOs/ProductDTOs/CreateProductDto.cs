namespace CasgemMicroservice.Services.Catalog.DTOs.ProductDTOs;

public class CreateProductDto
{
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductStock { get; set; }
    public string? ProductImage { get; set; }
    public string? CategoryId { get; set; }
}