using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateOrdering;

public sealed record CreateOrderingCommand(string UserId, decimal TotalPrice, DateTime OrderDate) : IRequest<CreateOrderingResponse>;