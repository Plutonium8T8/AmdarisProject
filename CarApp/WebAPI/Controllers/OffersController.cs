using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Model.DataTransferObject.Offer;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("{controller}")]
    [ApiController]
    public class OffersController : BaseController
    {
        private IOffersService _offersService { get; }

        public OffersController(IOffersService offersService)
        {
            _offersService = offersService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOffer(long id)
        {
            var result = await _offersService.GetOffer(id);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> DeleteOffer(long id)
        {
            await _offersService.DeleteOffer(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOffer([FromBody] OfferUpdateDTO offerUpdate)
        {
            await _offersService.UpdateOffer(offerUpdate);

            return Ok();
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> CreateOffer([FromBody] OfferCreateDTO offerCreate)
        {
            await _offersService.CreateOffer(offerCreate);

            return Ok();
        }
    }
}
