using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.DeleteOrderDetail;

public sealed record DeleteOrderDetailCommand(int Id) : IRequest;