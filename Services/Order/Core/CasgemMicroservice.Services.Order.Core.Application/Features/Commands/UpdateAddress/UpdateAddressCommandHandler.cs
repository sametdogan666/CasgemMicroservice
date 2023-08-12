using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateAddress;

internal sealed class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdateAddressResponse>
{
    private readonly IRepository<Address> _addressRepository;
    private readonly IMapper _mapper;

    public UpdateAddressCommandHandler(IRepository<Address> addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task<UpdateAddressResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var result = await _addressRepository.GetByIdAsync(request.Id);

        await _addressRepository.UpdateAsync(result);

        return _mapper.Map<UpdateAddressResponse>(result);
    }
}