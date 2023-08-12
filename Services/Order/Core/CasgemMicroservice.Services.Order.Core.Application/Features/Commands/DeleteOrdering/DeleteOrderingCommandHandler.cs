using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.DeleteOrdering;

internal sealed class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommand>
{
    private readonly IRepository<Ordering> _orderingRepository;

    public DeleteOrderingCommandHandler(IRepository<Ordering> orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }

    public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
    {
        var result = await _orderingRepository.GetByIdAsync(request.Id);

        await _orderingRepository.DeleteAsync(result);

    }
}