using CasgemMicroservice.Services.Basket.DTOs;
using CasgemMicroservice.Shared.DTOs;

namespace CasgemMicroservice.Services.Basket.Services;

public interface IBasketService
{
    Task<Response<BasketDto>> GetBasket(string userId);
    Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
    Task<Response<bool>> DeleteBasket(string userId);
}