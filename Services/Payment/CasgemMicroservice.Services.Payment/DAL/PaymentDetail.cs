namespace CasgemMicroservice.Services.Payment.DAL;

public class PaymentDetail
{
    public int Id { get; set; }
    public string? CartNumber { get; set; }
    public string? FullName { get; set; }
    public decimal Price { get; set; }
    public string? PaymentStatus { get; set; }

}