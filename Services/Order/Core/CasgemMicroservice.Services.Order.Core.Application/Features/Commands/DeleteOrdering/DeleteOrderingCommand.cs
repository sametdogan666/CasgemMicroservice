using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.DeleteOrdering;

public sealed record DeleteOrderingCommand(int Id) : IRequest;