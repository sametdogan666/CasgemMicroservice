using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateAddress;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.DeleteAddress;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateAddress;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllAddresses;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdAddress;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-list-addresses")]
        public async Task<IActionResult> GetListAddresses()
        {
            var response = await _mediator.Send(new GetAllAddressesQuery());

            return Ok(response);
        }

        [HttpGet("get-by-id-address/{id}")]
        public async Task<IActionResult> GetByIdAddress(int id)
        {
            var response = await _mediator.Send(new GetByIdAddressQuery(id));

            return Ok(response);
        }

        [HttpPost("create-address")]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _mediator.Send(new DeleteAddressCommand(id));

            return Ok("Adres silindi");
        }
    }
}
