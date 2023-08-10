using CasgemMicroservice.Services.Discount.DTOs;
using CasgemMicroservice.Services.Discount.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCouponsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountCouponsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet("get-list-coupons")]
        public async Task<IActionResult> GetListCoupons()
        {
            var result = await _discountService.GetListCouponsAsync();

            return Ok(result);
        }

        [HttpGet("get-coupon-by-id/{id}")]
        public async Task<IActionResult> GetCouponById([FromRoute] int id)
        {
            var result = await _discountService.GetCouponsAsync(id);

            return Ok(result);
        }

        [HttpPost("create-coupon")]
        public async Task<IActionResult> CreateCoupon(CreateDiscountCouponsDto createDiscountCouponsDto)
        {
            var value = _discountService.CreateCouponsAsync(createDiscountCouponsDto);

            return Ok("Oluşturma işlemi başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateDiscountCouponsDto updateDiscountCouponsDto)
        {
            await _discountService.UpdateCouponsAsync(updateDiscountCouponsDto);

            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteCouponsAsync(id);

            return Ok("Silme işlemi başarılı");
        }
    }
}
