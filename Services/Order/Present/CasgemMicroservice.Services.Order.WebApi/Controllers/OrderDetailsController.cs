using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateAddress;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.CreateOrderDetail;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.DeleteAddress;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.DeleteOrderDetail;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateAddress;
using CasgemMicroservice.Services.Order.Core.Application.Features.Commands.UpdateOrderDetail;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllAddresses;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetAllOrderDetails;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdAddress;
using CasgemMicroservice.Services.Order.Core.Application.Features.Queries.GetByIdOrderDetail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-list-order-details")]
        public async Task<IActionResult> GetListOrderDetails()
        {
            var response = await _mediator.Send(new GetAllOrderDetailsQuery());

            return Ok(response);
        }

        [HttpGet("get-by-id-order-detail/{id}")]
        public async Task<IActionResult> GetByIdOrderDetails(int id)
        {
            var response = await _mediator.Send(new GetByIdOrderDetailQuery(id));

            return Ok(response);
        }

        [HttpPost("create-order-detail")]
        public async Task<IActionResult> CreateAddress([FromBody] CreateOrderDetailCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _mediator.Send(new DeleteOrderDetailCommand(id));

            return Ok("Adres silindi");
        }
    }
}
