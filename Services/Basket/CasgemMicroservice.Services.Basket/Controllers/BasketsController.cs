using CasgemMicroservice.Services.Basket.DTOs;
using CasgemMicroservice.Services.Basket.Services;
using CasgemMicroservice.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BasketsController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet("get-basket")]
        public async Task<IActionResult> GetBasket()
        {
            var claims = User.Claims;

            return Ok(await _basketService.GetBasket(_sharedIdentityService.GetUserId));
        }

        [HttpPost("save-or-update-basket")]
        public async Task<IActionResult> SaveOrUpdateBasket([FromBody] BasketDto basketDto)
        {
            basketDto.UserId = _sharedIdentityService.GetUserId;
            var response = await _basketService.SaveOrUpdate(basketDto);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            return Ok(await _basketService.DeleteBasket(_sharedIdentityService.GetUserId));
        }
    }
}
