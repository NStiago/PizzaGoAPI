using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaGoAPI.Models;
using PizzaGoAPI.Services.MailServece;

namespace PizzaGoAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //временное использование сервиса, будет корректировка на CUD операции при использовании EF
        private readonly IMailService _mailService;
        public CategoryController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var result = new JsonResult(CategoryDataStore.Current.Categories);
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var categoryToReturn = CategoryDataStore.Current.Categories.FirstOrDefault(x => x.Id == id);

            if (categoryToReturn == null)
                return NotFound();

            //отправка сообщения при запросе категории
            _mailService.Send("sementiago", $"sending message from CategoryController and GetCategory with id: {id}");
            return Ok(categoryToReturn);
        }
    }
}
