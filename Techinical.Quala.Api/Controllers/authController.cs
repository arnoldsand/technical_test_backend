using Microsoft.AspNetCore.Mvc;
using Techinical.Quala.Api.Services;
using Techinical.Quala.Api.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Techinical.Quala.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class authController:ControllerBase
    {
        private readonly IJwtService _serviceJwt;
        private readonly IuserService _serviceAuth;

        public authController(IJwtService serviceJwt, IuserService serviceAuth)
        {
            _serviceJwt = serviceJwt;
            _serviceAuth = serviceAuth;
        }

        [HttpPost("login")]
        [AllowAnonymous] 
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }         
            var authenticatedUser = await _serviceAuth.ValidateUser(request.Username, request.Password);                       
            if (authenticatedUser == null)
            {                
                return Unauthorized(new { Message = "Credenciales inválidas." });
            }            
            var tokenString = _serviceJwt.GenerateToken(
                userId: authenticatedUser.Username,
                userName: authenticatedUser.Username,
                role: authenticatedUser.Role);

            
            return Ok(new
            {
                AccessToken = tokenString,
                TokenType = "Bearer",
                ExpiresIn = 30 * 60 
            });
        }


    }
}
