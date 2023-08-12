using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllAddresses;

internal sealed class GetAllAddressesHandler:IRequestHandler<GetAllAddressesQuery, List<GetAllAddressesResult>>
{
    private readonly IRepository<Address> _addressRepository;
    private readonly IMapper _mapper;

    public GetAllAddressesHandler(IRepository<Address> addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllAddressesResult>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
    {
        var result = await _addressRepository.GetAllAsync();

        return _mapper.Map<List<GetAllAddressesResult>>(result);
    }
}