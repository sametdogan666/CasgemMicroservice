using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllOrderingByUserId;

public sealed record GetAllOrderingByUserIdQuery() : IRequest<List<GetAllOrderingByUserIdResult>>
{
    public string? UserId { get; set; }
} 