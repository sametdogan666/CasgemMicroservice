using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateAddress;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateOrdering;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.DeleteAddress;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.DeleteOrdering;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateAddress;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateOrdering;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllAddresses;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllOrdering;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdAddress;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdOrdering;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-list-orderings")]
        public async Task<IActionResult> GetListOrderings()
        {
            var response = await _mediator.Send(new GetAllOrderingQuery());

            return Ok(response);
        }

        [HttpGet("get-by-id-ordering/{id}")]
        public async Task<IActionResult> GetByIdOrdering(int id)
        {
            var response = await _mediator.Send(new GetByIdOrderingQuery(id));

            return Ok(response);
        }

        [HttpPost("create-ordering")]
        public async Task<IActionResult> CreateOrdering([FromBody] CreateOrderingCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new DeleteOrderingCommand(id));

            return Ok("Adres silindi");
        }
    }
}
