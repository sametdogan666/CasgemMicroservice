using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using MediatR;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.Commands.DeleteAddress;

internal sealed class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
{
    private readonly IRepository<Address?> _addressRepository;

    public DeleteAddressCommandHandler(IRepository<Address?> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var result = await _addressRepository.GetByIdAsync(request.Id);
        await _addressRepository.DeleteAsync(result);
    }
}