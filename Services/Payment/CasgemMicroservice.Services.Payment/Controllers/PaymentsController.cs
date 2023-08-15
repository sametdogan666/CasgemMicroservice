using CasgemMicroservice.Services.Payment.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentContext _context;

        public PaymentsController(PaymentContext context)
        {
            _context = context;
        }

        [HttpGet("get-all-payments")]
        public IActionResult GetAllPayments()
        {
            var result = _context.PaymentDetails.ToList();

            return Ok(result);
        }

        [HttpPost("create-payment")]
        public IActionResult CreatePayment(PaymentDetail paymentDetail)
        {
            _context.PaymentDetails.Add(paymentDetail);

            return Ok("Ödeme yapıldı");
        }
    }
}
