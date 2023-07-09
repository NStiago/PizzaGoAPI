using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.Models;
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
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IOptions<JWTSettings> optionsAccess, IUnitOfWork unitOfWork)
        {
            _options = optionsAccess.Value;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetToken()
        {
            return Ok("API is validated");
        }
        //Доработать получение токена с юзером из БД
        [HttpPost]
        public IActionResult Auth(UserAuth user)
        {
            bool isValid = _unitOfWork.Users.IsValidUserInformation(user);
            if (isValid)
            {
                var tokenString=GenerateJWTToken(user.Login);
                return Ok(new {Token=tokenString, Message="Succes"});
            }
            return BadRequest("Invalid Username or Pass");
        }

        //исправить на юзера из бд
        private string GenerateJWTToken(string userName)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userName));

            var singingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(singingKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
