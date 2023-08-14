using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllOrderingByUserId;

internal sealed class GetAllOrderingByUserIdHandler:IRequestHandler<GetAllOrderingByUserIdQuery, List<GetAllOrderingByUserIdResult>>
{
    private readonly IRepository<Ordering> _orderingRepository;
    private readonly IMapper _mapper;

    public GetAllOrderingByUserIdHandler(IRepository<Ordering> orderingRepository, IMapper mapper)
    {
        _orderingRepository = orderingRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllOrderingByUserIdResult>> Handle(GetAllOrderingByUserIdQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderingRepository.FindByCondition(x=>x.UserId == request.UserId);

        return _mapper.Map<List<GetAllOrderingByUserIdResult>>(orders);
    }
}