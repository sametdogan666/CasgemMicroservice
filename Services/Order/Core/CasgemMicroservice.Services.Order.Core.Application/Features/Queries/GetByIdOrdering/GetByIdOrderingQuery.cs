using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdOrdering;

public sealed record GetByIdOrderingQuery(int Id) : IRequest<GetByIdOrderingResult>;
