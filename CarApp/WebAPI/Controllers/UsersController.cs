using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.DataTransferObject.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("{controller}")]
    [ApiController]
    public class UsersController : BaseController
    {
        private IUserService _userService { get; }

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var result = await _userService.GetUser(id);

            return Ok(result);
        }

/*        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            var result = await _userService.GetUserByUsername(username);

            return Ok(result);
        }*/

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            await _userService.DeleteUser(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDTO userUpdate)
        {
            await _userService.UpdateUser(userUpdate);

            return Ok();
        }

        [HttpGet("{id}/offers")]
        public async Task<IActionResult> GetUserOffers(long id)
        {
            var result = await _userService.GetUserOffers(id);

            return Ok(result);
        }
    }
}
