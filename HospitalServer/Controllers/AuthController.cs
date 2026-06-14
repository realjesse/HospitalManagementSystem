using HospitalServer.DTOs;
using HospitalServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        // Holds connection data for MongoDB and provides methods.
        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        // Controls when a user registers.
        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegisterRequest request)
        {
            var result = await _userService.RegisterAsync(request);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // Controls when a user logins in.
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginRequest request)
        {
            var result = await _userService.LoginAsync(request);

            if (!result.Success)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }
    }
}
