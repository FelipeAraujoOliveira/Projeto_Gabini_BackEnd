using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
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

        [HttpPost("signIn")]
        public async Task<ActionResult<string>> SignIn(SignInDTO signInDTO)
        {
            try
            {
                string token = await _authService.SignIn(signInDTO.Email, signInDTO.Password);
                return Ok(new { token });
            }
            catch (UnauthorizedAccessException ex)
            {
                // Retorna 401
                return Unauthorized(new
                {
                    message = ex.Message
                });
            }
        }
    }
}
