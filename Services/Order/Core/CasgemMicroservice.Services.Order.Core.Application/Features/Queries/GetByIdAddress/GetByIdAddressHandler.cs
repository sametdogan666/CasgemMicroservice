using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdAddress;

internal sealed class GetByIdAddressHandler : IRequestHandler<GetByIdAddressQuery, GetByIdAddressResult>
{
    private readonly IRepository<Address> _addressRepository;
    private readonly IMapper _mapper;

    public GetByIdAddressHandler(IRepository<Address> addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdAddressResult> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
    {
        var result = await _addressRepository.GetByIdAsync(request.Id);

        return _mapper.Map<GetByIdAddressResult>(result);
    }
}