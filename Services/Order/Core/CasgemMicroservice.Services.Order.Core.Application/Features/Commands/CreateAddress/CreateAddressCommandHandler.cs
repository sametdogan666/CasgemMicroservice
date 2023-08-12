using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateAddress;

public class CreateAddressCommandHandler:IRequestHandler<CreateAddressCommand, CreateAddressResponse>
{
    private readonly IRepository<Address> _addressRepository;
    private readonly IMapper _mapper;

    public CreateAddressCommandHandler(IRepository<Address> addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task<CreateAddressResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Address>(request);
        await _addressRepository.CreateAsync(result);

        return _mapper.Map<CreateAddressResponse>(result);
    }
}