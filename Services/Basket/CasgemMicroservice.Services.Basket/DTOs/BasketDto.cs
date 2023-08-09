﻿namespace CasgemMicroservice.Services.Basket.DTOs;

public class BasketDto
{
    public string? UserId { get; set; }
    public string? DiscountCode { get; set; }
    public int? DiscountRate { get; set; }
    public List<BasketItemDto>? BasketItems { get; set; } 

    public decimal TotalPrice => BasketItems.Sum(x => x.ProductPrice * x.Quantity);
}