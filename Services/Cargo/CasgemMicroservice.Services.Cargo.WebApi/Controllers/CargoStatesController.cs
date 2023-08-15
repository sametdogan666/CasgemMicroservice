using CasgemMicroservice.Services.Cargo.Business.Abstract;
using CasgemMicroservice.Services.Cargo.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoStatesController : ControllerBase
    {
        private readonly ICargoStateService _cargoStateService;

        public CargoStatesController(ICargoStateService cargoStateService)
        {
            _cargoStateService = cargoStateService;
        }

        [HttpGet("get-cargo-state-by-id/{id}")]
        public IActionResult GetCargoStateById(int id)
        {
            var response = _cargoStateService.GetById(id);
            return Ok(response);
        }

        [HttpGet("get-all-cargo-states")]
        public IActionResult GetAllCargoStates()
        {
            var response = _cargoStateService.GetAll();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateCargoState(CargoState cargoState)
        {
            _cargoStateService.Insert(cargoState);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCargoState(CargoState cargoState)
        {
            _cargoStateService.Update(cargoState);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCargoState(CargoState cargoState)
        {
            _cargoStateService.Delete(cargoState);

            return Ok();
        }
    }
}
