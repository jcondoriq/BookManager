using BookManager.BusinessObjects.DTOs.Login;
using BookManager.BusinessObjects.Interfaces.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly ILoginController LoginController;

        public AuthController(ILoginController loginController)
        {
            LoginController = loginController;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async ValueTask<IActionResult> Login([FromBody] UserCredentialsDto dto)
        {
            var token = await LoginController.Login(dto);
            return Ok(token);
        }
    }
}
