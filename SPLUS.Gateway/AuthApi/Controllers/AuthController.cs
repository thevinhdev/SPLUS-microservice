using AuthApi.Models;
using AuthApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;

        public AuthController(JwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("GenerateToken")]
        public IActionResult GenerateToken([FromBody] LoginModel user)
        {
            var loginResult = _jwtTokenService.GenerateAuthToken(user);

            return loginResult is null ? Unauthorized() : Ok(loginResult);
        }

        [Authorize]
        [HttpPost("GenerateRefreshToken")]
        public IActionResult GenerateRefreshToken(RefreshTokenModel tokenModel)
        {
            var loginResult = _jwtTokenService.GenerateRefreshToken(tokenModel);

            return loginResult is null ? Unauthorized() : Ok(loginResult);
        }
    }
}
