using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.DeleteAddress;

public sealed record DeleteAddressCommand(int Id) : IRequest;