using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PizzaGoAPI.Services.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PizzaGoAPI.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController:ControllerBase
    {
        private readonly JWTSettings _options;
        public AccountController(IOptions<JWTSettings> optionsAccess)
        {
            _options = optionsAccess.Value;
        }
        [HttpGet]
        public IActionResult GetToken()
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "testUser"));
            claims.Add(new Claim("skillsOfProgramming","junior"));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            var singingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(singingKey,SecurityAlgorithms.HmacSha256)
                );
            return Ok((new JwtSecurityTokenHandler().WriteToken(jwt)));
        }
    }
}
