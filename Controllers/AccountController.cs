using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PizzaGoAPI.Services.Authorization;

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
    }
}
