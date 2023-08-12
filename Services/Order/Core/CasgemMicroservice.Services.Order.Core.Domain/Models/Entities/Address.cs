﻿namespace CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;

public class Address
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
    public string? Detail { get; set; }
}