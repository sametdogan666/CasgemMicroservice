using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdOrdering;

internal sealed class GetByIdOrderingHandler : IRequestHandler<GetByIdOrderingQuery, GetByIdOrderingResult>
{
    private readonly IRepository<Ordering> _orderingRepository;
    private readonly IMapper _mapper;

    public GetByIdOrderingHandler(IRepository<Ordering> orderingRepository, IMapper mapper)
    {
        _orderingRepository = orderingRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdOrderingResult> Handle(GetByIdOrderingQuery request, CancellationToken cancellationToken)
    {
        var result = await _orderingRepository.GetByIdAsync(request.Id);

        return _mapper.Map<GetByIdOrderingResult>(result);
    }
}