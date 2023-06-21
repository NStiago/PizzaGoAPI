using Microsoft.AspNetCore.Mvc;
using PizzaGoAPI.Models;

namespace PizzaGoAPI.Controllers
{
    [ApiController]
    [Route("api/categories/{categoryId}/products")]
    public class ProductController : ControllerBase
    {
        //[HttpGet]
        //public ActionResult<IEnumerable<Product>> GetProducts()
        //{
        //    var result;
        //    return result;
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Product> GetProduct(int id)
        //{
        //    var result;
        //    return result;
        //}

    }
}
