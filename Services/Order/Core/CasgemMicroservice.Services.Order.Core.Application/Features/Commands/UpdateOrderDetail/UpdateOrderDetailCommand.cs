using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateOrderDetail;

public sealed record UpdateOrderDetailCommand(int Id) : IRequest<UpdateOrderDetailResponse>;