using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateAddress;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateOrdering;

internal sealed class CreateOrderingCommandHandler:IRequestHandler<CreateOrderingCommand, CreateOrderingResponse>
{
    private readonly IRepository<Ordering> _orderingRepository;
    private readonly IMapper _mapper;

    public CreateOrderingCommandHandler(IRepository<Ordering> orderingRepository, IMapper mapper)
    {
        _orderingRepository = orderingRepository;
        _mapper = mapper;
    }

    public async Task<CreateOrderingResponse> Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Ordering>(request);
        await _orderingRepository.CreateAsync(result);

        return _mapper.Map<CreateOrderingResponse>(result);
    }
}