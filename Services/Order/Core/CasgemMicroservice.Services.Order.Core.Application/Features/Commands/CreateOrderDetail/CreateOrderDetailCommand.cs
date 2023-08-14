using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateOrderDetail;

public sealed record CreateOrderDetailCommand(int ProductId, string ProductName, decimal ProductPrice, int ProductAmount, int OrderingId) : IRequest<CreateOrderDetailResponse>;