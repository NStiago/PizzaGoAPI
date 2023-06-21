using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaGoAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCategories()
        {
            var result = new JsonResult(CategoryDataStore.Current.Categories);
            return result;
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var categoryToReturn = CategoryDataStore.Current.Categories.FirstOrDefault(x => x.Id == id);

            if (categoryToReturn == null)
                return NotFound();
            return Ok(categoryToReturn);
        }
    }
}
