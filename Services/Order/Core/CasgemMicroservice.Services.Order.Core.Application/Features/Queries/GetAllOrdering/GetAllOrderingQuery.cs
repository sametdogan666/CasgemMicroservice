using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllOrdering;

public sealed record GetAllOrderingQuery : IRequest<List<GetAllOrderingResult>>;
