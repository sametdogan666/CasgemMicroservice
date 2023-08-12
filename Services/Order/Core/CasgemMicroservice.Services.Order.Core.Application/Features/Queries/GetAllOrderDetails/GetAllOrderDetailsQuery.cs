using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllOrderDetails;

public sealed record GetAllOrderDetailsQuery() : IRequest<List<GetAllOrderDetailsResult>>;