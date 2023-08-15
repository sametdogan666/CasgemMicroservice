using CasgemMicroservice.Services.Cargo.Business.Abstract;
using CasgemMicroservice.Services.Cargo.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet("get-cargo-detail-by-id/{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var response = _cargoDetailService.GetById(id);
            return Ok(response);
        }

        [HttpGet("get-all-cargo-details")]
        public IActionResult GetAllCargoDetails()
        {
            var response = _cargoDetailService.GetAll();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CargoDetail cargoDetail)
        {
            _cargoDetailService.Insert(cargoDetail);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(CargoDetail cargoDetail)
        {
            _cargoDetailService.Update(cargoDetail);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(CargoDetail cargoDetail)
        {
            _cargoDetailService.Delete(cargoDetail);

            return Ok();
        }
    }
}
