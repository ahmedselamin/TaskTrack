using Microsoft.AspNetCore.Mvc;
using TaskTrack.Server.Services.AuthService;

namespace TaskTrack.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] UserRegisterDTO request)
        {
            var response = await _authService
                .Register(
                    new User
                    {
                        Username = request.Username,
                    },
                    request.Password
                );

            return response.Success ? Ok(response) : BadRequest(response.Message);
        }
    }
}
