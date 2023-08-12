using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdOrderDetail;

internal sealed class GetByIdOrderDetailHandler : IRequestHandler<GetByIdOrderDetailQuery, GetByIdOrderDetailResult>
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;
    private readonly IMapper _mapper;

    public GetByIdOrderDetailHandler(IRepository<OrderDetail> orderDetailRepository, IMapper mapper)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdOrderDetailResult> Handle(GetByIdOrderDetailQuery request, CancellationToken cancellationToken)
    {
        var result = await _orderDetailRepository.GetByIdAsync(request.Id);

        return _mapper.Map<GetByIdOrderDetailResult>(result);
    }
}