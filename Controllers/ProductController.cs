using Microsoft.AspNetCore.Mvc;

namespace PizzaGoAPI.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("api/pizza")]
        public IActionResult GetProducts()
        {
            return new JsonResult(new List<object>
            {
                new {id =1, Name="Pepperoni"},
                new {id=2, Name="Pizza with Pineapple"}
            });
        }
    }
}
