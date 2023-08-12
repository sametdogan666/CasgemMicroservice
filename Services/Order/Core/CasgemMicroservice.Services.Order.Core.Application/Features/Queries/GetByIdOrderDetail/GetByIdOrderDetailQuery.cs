using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdOrderDetail;

public sealed record GetByIdOrderDetailQuery(int Id) : IRequest<GetByIdOrderDetailResult>;