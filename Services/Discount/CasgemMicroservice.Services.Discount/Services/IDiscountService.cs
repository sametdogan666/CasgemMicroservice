using CasgemMicroservice.Services.Discount.DTOs;
using CasgemMicroservice.Services.Discount.Models;
using CasgemMicroservice.Shared.DTOs;

namespace CasgemMicroservice.Services.Discount.Services;

public interface IDiscountService
{
    Task<Response<List<ResultDiscountCouponsDto>>> GetListCouponsAsync();
    Task<Response<ResultDiscountCouponsDto>> GetCouponsAsync(int id);
    Task<Response<NoContent>> CreateCouponsAsync(CreateDiscountCouponsDto discountCouponsDto);
    Task<Response<NoContent>> UpdateCouponsAsync(UpdateDiscountCouponsDto discountCouponsDto);
    Task<Response<NoContent>> DeleteCouponsAsync(int id);
}