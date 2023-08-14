using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateAddress;

public sealed record CreateAddressCommand(string? UserId, string? District, string? City, string? Detail) : IRequest<CreateAddressResponse>;