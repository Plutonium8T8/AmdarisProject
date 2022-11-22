using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.DataTransferObject.Payment;
using WebAPI.Model.DataTransferObject.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("{controller}")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private IPaymentService _peymentService { get; }

        public PaymentController(IPaymentService peymentService)
        {
            _peymentService = peymentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(PaymentDTO token)
        {
            await _peymentService.CreateCharge(token.Token, 3000);
            return Ok();
        }
    }
}
