using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.DeleteOrderDetail;

internal sealed class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand>
{
    private readonly IRepository<OrderDetail?> _orderDetailRepository;

    public DeleteOrderDetailCommandHandler(IRepository<OrderDetail?> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var result = await _orderDetailRepository.GetByIdAsync(request.Id);
        await _orderDetailRepository.DeleteAsync(result);
    }
}