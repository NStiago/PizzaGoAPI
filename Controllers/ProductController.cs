using Microsoft.AspNetCore.Mvc;
using PizzaGoAPI.Models;

namespace PizzaGoAPI.Controllers
{
    [ApiController]
    [Route("api/categories/{categoryId}/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts(int categoryId)
        {
            var category = CategoryDataStore.Current.Categories.FirstOrDefault(x => x.Id == categoryId);
            if (category == null)
                return NotFound();

            return Ok(category.Products);
        }

        [HttpGet("{productId}")]
        public ActionResult<ProductDTO> GetProduct(int categoryId, int productId)
        {
            //получение категории
            var category = CategoryDataStore.Current.Categories.FirstOrDefault(x => x.Id == categoryId);

            if (category == null)
                return NotFound();
            //получение продукта
            var product = category.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null)
                return NotFound();

            return product;
        }

    }
}
