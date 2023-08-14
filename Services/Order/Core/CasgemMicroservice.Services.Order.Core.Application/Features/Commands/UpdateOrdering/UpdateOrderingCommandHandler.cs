using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateOrdering;

internal sealed class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand, UpdateOrderingResponse>
{
    private readonly IRepository<Ordering?> _orderingRepository;
    private readonly IMapper _mapper;

    public UpdateOrderingCommandHandler(IRepository<Ordering?> orderingRepository, IMapper mapper)
    {
        _orderingRepository = orderingRepository;
        _mapper = mapper;
    }

    public async Task<UpdateOrderingResponse> Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var result = await _orderingRepository.GetByIdAsync(request.Id);
        result.OrderDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        result.TotalPrice = request.TotalPrice;
        result.UserId = request.UserId;
        await _orderingRepository.UpdateAsync(result);

        return _mapper.Map<UpdateOrderingResponse>(result);
    }
}