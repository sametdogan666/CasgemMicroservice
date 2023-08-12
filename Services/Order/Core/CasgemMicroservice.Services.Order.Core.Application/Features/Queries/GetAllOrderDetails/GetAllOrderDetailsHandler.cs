using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllOrderDetails;

public class GetAllOrderDetailsHandler : IRequestHandler<GetAllOrderDetailsQuery, List<GetAllOrderDetailsResult>>
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;
    private readonly IMapper _mapper;

    public GetAllOrderDetailsHandler(IRepository<OrderDetail> orderDetailRepository, IMapper mapper)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllOrderDetailsResult>> Handle(GetAllOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _orderDetailRepository.GetAllAsync();

        return _mapper.Map<List<GetAllOrderDetailsResult>>(result);
    }
}