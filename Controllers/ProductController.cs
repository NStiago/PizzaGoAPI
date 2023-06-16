using Microsoft.AspNetCore.Mvc;

namespace PizzaGoAPI.Controllers
{
    [ApiController]
    [Route("api/pizza")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            return new JsonResult(ProductDataStore.Current.Pizzas);
        }
    }
}
