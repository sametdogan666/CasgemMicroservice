using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateOrderDetail;

internal sealed class UpdateOrderDetailCommandHandler:IRequestHandler<UpdateOrderDetailCommand, UpdateOrderDetailResponse>
{
    private readonly IRepository<OrderDetail?> _orderDetailRepository;
    private readonly IMapper _mapper;

    public UpdateOrderDetailCommandHandler(IRepository<OrderDetail?> orderDetailRepository, IMapper mapper)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
    }

    public async Task<UpdateOrderDetailResponse> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var result = await _orderDetailRepository.GetByIdAsync(request.Id);
        result.ProductName = request.ProductName;
        result.ProductPrice = request.ProductPrice;
        result.ProductId = request.ProductId;
        result.ProductAmount = request.ProductAmount;
        result.OrderingId = request.OrderingId;
        await _orderDetailRepository.UpdateAsync(result);

        return _mapper.Map<UpdateOrderDetailResponse>(result);
    }
}