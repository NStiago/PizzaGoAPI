using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.Entities;
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
        private readonly IMapper _mapper;
        public AccountController(IOptions<JWTSettings> optionsAccess, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _options = optionsAccess.Value;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetToken()
        {
            return Ok("API is validated");
        }

        [HttpPost]
        public async Task<IActionResult> Auth(UserDTOAuth user)
        {
            User validUser = await _unitOfWork.Users.GetValidUser(user);
            if (validUser != null)
            {
                var tokenString = GenerateJWTToken(validUser);
                return Ok(new { Token = tokenString, Message = "Succes" });
            }
            return Unauthorized("Invalid Username or Pass");
        }
        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup(UserDTOforRegistration user)
        {
            if (await _unitOfWork.Users.IsInvalidUserLogin(user.Login))
                return BadRequest("Invalid Login!");
            var userToDB = _mapper.Map<User>(user);
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            userToDB.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
            _unitOfWork.Users.Create(userToDB);
            await _unitOfWork.Save();
            return Ok("User succesfully created!");
        }

        private string GenerateJWTToken(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Login));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

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
