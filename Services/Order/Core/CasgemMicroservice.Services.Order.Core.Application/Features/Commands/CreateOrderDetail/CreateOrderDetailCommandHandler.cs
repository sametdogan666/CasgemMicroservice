using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateOrdering;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateOrderDetail;

public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, CreateOrderDetailResponse>
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;
    private readonly IMapper _mapper;

    public CreateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository, IMapper mapper)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
    }

    public async Task<CreateOrderDetailResponse> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
    {

        var result = new OrderDetail
        {
            ProductId = request.ProductId,
            ProductName = request.ProductName,
            ProductPrice = request.ProductPrice,
            ProductAmount = request.ProductAmount,
            OrderingId = request.OrderingId
        };

        //var result = _mapper.Map<OrderDetail>(request);
        await _orderDetailRepository.CreateAsync(result);

        return _mapper.Map<CreateOrderDetailResponse>(result);
    }
}