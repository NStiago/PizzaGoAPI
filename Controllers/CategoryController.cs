using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMailService _mailService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryController(IMailService mailService, PizzaAppContext context, IMapper mapper)
        { 
            _mailService = mailService;
            _unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categoryEntities = await _unitOfWork.GetRepository<Category>().GetAllAsync(include: x=>x.Include(z=>z.Products));
            return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categoryEntities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var categoryToReturn = _unitOfWork.GetRepository<Category>().Get(id);

            if (categoryToReturn == null)
                return NotFound();

            //отправка сообщения при запросе категории
            _mailService.Send("sementiago", $"sending message from CategoryController and GetCategory with id: {id}");
            return Ok(_mapper.Map<CategoryDTO>(categoryToReturn));
        }
    }
}
