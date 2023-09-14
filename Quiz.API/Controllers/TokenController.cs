using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Quiz.API.Controllers
{
    public class TokenController : Controller
    {
        private readonly IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Generates token
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("token")]
        public ActionResult GetToken()
        {
            var token = GenerateToken();

            if (token != null)
                return Ok(token);

            return NotFound();
        }

        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["JwtSettings:Issuer"],
                                             _config["JwtSettings:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddHours(1),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
