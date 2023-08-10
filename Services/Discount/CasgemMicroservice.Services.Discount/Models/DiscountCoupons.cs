﻿namespace CasgemMicroservice.Services.Discount.Models;

public class DiscountCoupons
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public int Rate { get; set; }
    public string? Code { get; set; }
    public DateTime CreatedTime { get; set; }

}