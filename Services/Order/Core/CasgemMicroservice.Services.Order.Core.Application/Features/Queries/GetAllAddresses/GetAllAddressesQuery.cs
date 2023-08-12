using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllAddresses;

public sealed record GetAllAddressesQuery() :IRequest<List<GetAllAddressesResult>>;