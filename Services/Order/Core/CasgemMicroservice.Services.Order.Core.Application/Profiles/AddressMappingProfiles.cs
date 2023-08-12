using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateAddress;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateAddress;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllAddresses;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdAddress;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;

namespace CasgemMicroservice.Services.Order.Core.Application.Profiles;

public class AddressMappingProfiles : Profile
{
    public AddressMappingProfiles()
    {
        CreateMap<Address, GetAllAddressesResult>().ReverseMap();
        CreateMap<Address, GetByIdAddressResult>().ReverseMap();
        CreateMap<Address, CreateAddressResponse>().ReverseMap();
        CreateMap<Address, UpdateAddressResponse>().ReverseMap();
    }
}