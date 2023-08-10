using AutoMapper;
using CasgemMicroservice.Services.Discount.DTOs;
using CasgemMicroservice.Services.Discount.Models;

namespace CasgemMicroservice.Services.Discount.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<DiscountCoupons, ResultDiscountCouponsDto>().ReverseMap();
        CreateMap<DiscountCoupons, CreateDiscountCouponsDto>().ReverseMap();
        CreateMap<DiscountCoupons, UpdateDiscountCouponsDto>().ReverseMap();
    }
}