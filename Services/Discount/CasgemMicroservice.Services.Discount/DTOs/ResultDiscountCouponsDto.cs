namespace CasgemMicroservice.Services.Discount.DTOs;

public class ResultDiscountCouponsDto
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public int Rate { get; set; }
    public string? Code { get; set; }
    public DateTime CreatedTime { get; set; }
}