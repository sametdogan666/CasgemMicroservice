using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllOrdering;

internal sealed class GetAllOrderingHandler : IRequestHandler<GetAllOrderingQuery, List<GetAllOrderingResult>>
{
    private readonly IRepository<Ordering> _orderingRepository;
    private readonly IMapper _mapper;

    public GetAllOrderingHandler(IRepository<Ordering> orderingRepository, IMapper mapper)
    {
        _orderingRepository = orderingRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllOrderingResult>> Handle(GetAllOrderingQuery request, CancellationToken cancellationToken)
    {
        var result = await _orderingRepository.GetAllAsync();

        return _mapper.Map<List<GetAllOrderingResult>>(result);
    }
}