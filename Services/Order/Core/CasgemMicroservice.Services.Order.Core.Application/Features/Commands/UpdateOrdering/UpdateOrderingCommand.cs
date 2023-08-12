using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateOrdering;

public sealed record UpdateOrderingCommand(int Id):IRequest<UpdateOrderingResponse>;