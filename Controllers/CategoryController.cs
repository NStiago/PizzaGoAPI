﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger _logger;
        public CategoryController(IMailService mailService, IUnitOfWork unitOfWork, IMapper mapper, ILogger<CategoryController> logger)
        {
            _mailService = mailService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTOWithoutProduct>>> GetCategories()
        {
            var categoryEntities = await _unitOfWork.Categories.GetAllAsync();
            _logger.LogInformation($"Get a count of Category: {await _unitOfWork.Categories.GetCountAsync()}");
            return Ok(_mapper.Map<IEnumerable<CategoryDTOWithoutProduct>>(categoryEntities));
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategory(int id, bool includeProduct = false)
        {
            var categoryToReturn = _unitOfWork.Categories.GetAsync(id, includeProduct).Result;
            if (categoryToReturn == null)
            {
                _logger.LogInformation($"Category with Id: {id} Not Found");
                return NotFound();
            }

            //отправка сообщения при запросе категории
            _mailService.Send("sementiago", $"sending message from CategoryController and GetCategory with id: {id}");

            if (includeProduct)
            {
                _logger.LogInformation($"Get a Category with ID: {categoryToReturn.Id}");
                return Ok(_mapper.Map<CategoryDTO>(categoryToReturn));
            }
            _logger.LogInformation($"Get a Category with ID: {categoryToReturn.Id}");
            return Ok(_mapper.Map<CategoryDTOWithoutProduct>(categoryToReturn));

        }
        [HttpPost]
        [Authorize(Policy = "IsAdmin")]
        public async Task<ActionResult<CategoryDTOWithoutProduct>> CreateCategory(CategoryDTOForCreation inputCategory)
        {
            var resultCategory = _mapper.Map<Category>(inputCategory);
            if(await _unitOfWork.Categories.IncludeNameAsync(inputCategory.Name))
                return BadRequest($"Категория с именем{inputCategory.Name} уже существует");

            await _unitOfWork.Categories.CreateAsync(resultCategory);
            await _unitOfWork.Save();
            

            var returnCategory = _mapper.Map<CategoryDTOWithoutProduct>(resultCategory);
            _logger.LogInformation($"Create a Category with ID: {returnCategory.Id}");
            return CreatedAtRoute("GetCategory", new 
            {
               id= returnCategory.Id,
            },
            returnCategory);
        }
        [HttpPut("{id}")]
        [Authorize(Policy = "IsAdmin")]
        public async Task<ActionResult> UpdateCategory(int id, CategoryDTOForCreation inputCategory)
        {
            var categoryForUpdate = await _unitOfWork.Categories.GetAsync(id);
            if (categoryForUpdate==null)
            {
                _logger.LogInformation($"Category with Id: {id} Not Found");
                return NotFound();
            }
            
            _mapper.Map(inputCategory, categoryForUpdate);
            _logger.LogInformation($"Update a Category with ID: {categoryForUpdate.Id}");
            await _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "IsAdmin")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            
            if (!await _unitOfWork.Categories.CategoryExistAsync(id))
            {
                _logger.LogInformation($"Category with Id: {id} Not Found");
                return NotFound();
            }

            _unitOfWork.Categories.Delete(id);
            await _unitOfWork.Save();
            _logger.LogInformation($"Delete a Category with ID: {id}");
            return NoContent();
        }
    }
}
