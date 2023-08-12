using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdAddress;

public sealed record GetByIdAddressQuery(int Id) : IRequest<GetByIdAddressResult>;