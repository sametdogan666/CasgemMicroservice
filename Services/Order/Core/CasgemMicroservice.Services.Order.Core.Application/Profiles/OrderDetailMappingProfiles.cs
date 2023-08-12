using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateOrderDetail;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateOrderDetail;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllOrderDetails;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdOrderDetail;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;

namespace CasgemMicroservice.Services.Order.Core.Application.Profiles;

public class OrderDetailMappingProfiles : Profile
{
    public OrderDetailMappingProfiles()
    {
        CreateMap<OrderDetail, GetAllOrderDetailsResult>().ReverseMap();
        CreateMap<OrderDetail, GetByIdOrderDetailResult>().ReverseMap();
        CreateMap<OrderDetail, CreateOrderDetailResponse>().ReverseMap();
        CreateMap<OrderDetail, UpdateOrderDetailResponse>().ReverseMap();
    }
}