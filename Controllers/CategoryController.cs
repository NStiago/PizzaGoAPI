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
        public CategoryController(IMailService mailService, IUnitOfWork unitOfWork, IMapper mapper)
        { 
            _mailService = mailService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTOWithoutProduct>>> GetCategories()
        {
            var categoryEntities = await _unitOfWork.Categories.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDTOWithoutProduct>>(categoryEntities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id, bool includeProduct=false)
        {
            var categoryToReturn = _unitOfWork.Categories.GetAsync(id,includeProduct).Result;

            if (categoryToReturn == null)
                return NotFound();

            //отправка сообщения при запросе категории
            _mailService.Send("sementiago", $"sending message from CategoryController and GetCategory with id: {id}");

            if (includeProduct)
            {
                return Ok(_mapper.Map<CategoryDTO>(categoryToReturn));
            }
            return Ok(_mapper.Map<CategoryDTOWithoutProduct>(categoryToReturn));
        }
    }
}
