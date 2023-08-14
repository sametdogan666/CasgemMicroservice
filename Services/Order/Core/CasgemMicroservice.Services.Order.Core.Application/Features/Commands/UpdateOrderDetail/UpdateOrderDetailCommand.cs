using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateOrderDetail;

public sealed record UpdateOrderDetailCommand(int Id, int ProductId, string? ProductName, decimal ProductPrice, int ProductAmount, int OrderingId) : IRequest<UpdateOrderDetailResponse>;