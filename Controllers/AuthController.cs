﻿using Microsoft.AspNetCore.Mvc;
using GabiniBackEnd.Services;

namespace GabiniBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<bool>> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Senha))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            bool resultado = await _authService.Login(request.Email, request.Senha);
            return Ok(resultado);
        }
    }

    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
