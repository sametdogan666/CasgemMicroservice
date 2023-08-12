﻿namespace CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;

public class Ordering
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderDetail>? OrderDetails { get; set; }

}