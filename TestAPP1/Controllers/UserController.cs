using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TestAPP1.Core;
using TestAPP1.Core.Models;

namespace TestAPP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        JwtSetting _jwts;
        public UserController(IConfiguration  configuration)
        {
           configuration.GetSection("JwtSetting").Bind(_jwts);

        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel login)
        {
            if (login.UserName == "admin" && login.Password == "admin")
            {
                var token = JwtTokenGenerator.GenerateToken(login.UserName, _jwts);
                return Ok(token);
            }
            return Unauthorized();
        }
    }

    public class JwtTokenGenerator
    {
        public static string? GenerateToken(string username, JwtSetting jwtSetting)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSetting.Key);
            var array = new[]
                { new Claim(ClaimTypes.Name, username) ,
                    new Claim(ClaimTypes.NameIdentifier, "1002")  };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(array),
                Audience = jwtSetting.Audience,
                Issuer = jwtSetting.Issuer,
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
