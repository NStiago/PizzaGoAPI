using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.DataAccess.Repositories;
using PizzaGoAPI.DBContext;
using PizzaGoAPI.Entities;
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
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IMailService mailService, PizzaAppContext context)
        { 
            _mailService = mailService;
            _unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTOWithoutChild>>> GetCategories()
        {
            var categoryEntities = await _unitOfWork.GetRepository<Category>().GetAllAsync();
            var result = new List<CategoryDTOWithoutChild>();
            foreach(var category in categoryEntities)
            {
                result.Add(new CategoryDTOWithoutChild
                {
                    Id = category.Id,
                    Name = category.Name,
                });
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var categoryToReturn = _unitOfWork.GetRepository<Category>().Get(id);

            if (categoryToReturn == null)
                return NotFound();

            //отправка сообщения при запросе категории
            _mailService.Send("sementiago", $"sending message from CategoryController and GetCategory with id: {id}");
            return Ok(categoryToReturn);
        }
    }
}
