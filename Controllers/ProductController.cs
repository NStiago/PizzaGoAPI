using Microsoft.AspNetCore.Mvc;

namespace PizzaGoAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = new JsonResult(ProductDataStore.Current.Products);
            return result;
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id) 
        {
            var productToReturn = ProductDataStore.Current.Products.FirstOrDefault(x => x.Id == id);

            if(productToReturn==null)
                return NotFound();
            return Ok(productToReturn);
        }

    }
}
