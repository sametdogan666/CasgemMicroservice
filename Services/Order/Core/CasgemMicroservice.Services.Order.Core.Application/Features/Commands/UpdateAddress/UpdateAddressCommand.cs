using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateAddress;

public sealed record UpdateAddressCommand(int Id, string? UserId, string? District, string? City, string? Detail) : IRequest<UpdateAddressResponse>;