using Microsoft.AspNetCore.Mvc;
using PizzaGoAPI.Models;

namespace PizzaGoAPI.Controllers
{
    [ApiController]
    [Route("api/categories/{categoryId}/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts(int categoryId)
        {
            var category = CategoryDataStore.Current.Categories.FirstOrDefault(x => x.Id == categoryId);

            if (category == null)
                return NotFound();
            return Ok(category.Products);
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetProduct(int categoryId, int productId)
        {
            var category = CategoryDataStore.Current.Categories.FirstOrDefault(x => x.Id == categoryId);

            if (category == null)
                return NotFound();
            //поиск продукта
            var product = category.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null)
                return NotFound();

            return product;
        }

    }
}
