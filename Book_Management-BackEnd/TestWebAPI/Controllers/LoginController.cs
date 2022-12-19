using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Models.Users;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest loginRequest)
        {
            var response = _userService.Login(loginRequest);
            return response;
        }
    }
}