using JWTLoginRegister.Dtos;
using JWTLoginRegister.Helpers.Jwt;
using JWTLoginRegister.Models;
using JWTLoginRegister.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWTLoginRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] UserDto dto)
        {
            var user = UserRepository.GetUser(dto);
            if(user != null)
            {
                var token = TokenService.GenerateToken(user, _config);
                return Ok(token);
            }
            return NotFound("notfound");
        }

        [HttpGet("some")]
        public IActionResult SomeMethod()
        {
            var user = GetUser();
            return Ok($"Salam {user?.UserName}");
        }

        private User GetUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new User
                {
                    UserName = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
