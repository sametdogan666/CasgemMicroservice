﻿namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdAddress;

public class GetByIdAddressResult
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
    public string? Detail { get; set; }
}