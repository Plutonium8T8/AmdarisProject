using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebAPI.Model.DataTransferObject.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("{controller}")]
    [ApiController]
    public class AuthController : BaseController
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] RegisterUserDTO registerUser)
        {
            Console.WriteLine(registerUser.Username);
            Console.WriteLine(registerUser.Password);
            Console.WriteLine(registerUser.Email);
            Console.WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);
            var result = await _authService.RegisterUser(registerUser);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUser)
        {
            var result = await _authService.Login(loginUser);
            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogOut();
            return Ok(new { });
        }
    }
}
