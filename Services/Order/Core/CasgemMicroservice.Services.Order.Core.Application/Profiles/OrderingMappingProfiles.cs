using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateOrdering;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateOrdering;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllOrdering;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllOrderingByUserId;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdOrdering;

namespace CasgemMicroservice.Services.Order.Core.Application.Profiles;

public class OrderingMappingProfiles : Profile
{
    public OrderingMappingProfiles()
    {
        CreateMap<Domain.Models.Entities.Ordering, GetAllOrderingResult>().ReverseMap();
        CreateMap<Domain.Models.Entities.Ordering, GetByIdOrderingResult>().ReverseMap();
        CreateMap<Domain.Models.Entities.Ordering, CreateOrderingResponse>().ReverseMap();
        CreateMap<Domain.Models.Entities.Ordering, UpdateOrderingResponse>().ReverseMap();
        CreateMap<Domain.Models.Entities.Ordering, GetAllOrderingByUserIdResult>().ReverseMap();
    }
}