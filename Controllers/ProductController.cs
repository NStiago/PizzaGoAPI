﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.Entities;
using PizzaGoAPI.Models;

namespace PizzaGoAPI.Controllers
{
    [ApiController]
    [Route("api/categories/{categoryId}/products")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductController> logger)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
            _logger=logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts(int categoryId)
        {
            if(!await _unitOfWork.Categories.CategoryExistAsync(categoryId))
            {
                _logger.LogInformation($"Category with Id: {categoryId} Not Found");
                return NotFound();
            }
            _logger.LogInformation($"Get a count of Product: {await _unitOfWork.Products.GetCountProductFromCategory(categoryId)} " +
                $"from Category {categoryId}");
            var productsToReturn = await _unitOfWork.Products.GetProductsOfCategory(categoryId);
            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(productsToReturn));
        }

        [HttpGet("{productId}", Name ="GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int categoryId, int productId)
        {
            if (!await _unitOfWork.Categories.CategoryExistAsync(categoryId))
            {
                _logger.LogInformation($"Category with Id: {categoryId} Not Found");
                return NotFound();
            }
            var productToReturn = await _unitOfWork.Products.GetAsync(productId);
            if(productToReturn == null)
            {
                _logger.LogInformation($"Product with Id: {productId} Not Found");
                return NotFound();
            }
            _logger.LogInformation($"Get a Product {productId} from {categoryId}");
            return Ok(_mapper.Map<ProductDTO>(productToReturn));
        }
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct(int categoryId, ProductDTOForCreation product)
        {
            if (!await _unitOfWork.Categories.CategoryExistAsync(categoryId))
            {
                _logger.LogInformation($"Category with Id: {categoryId} Not Found");
                return NotFound();
            }
            var resultProduct = _mapper.Map<Product>(product);
            if (await _unitOfWork.Products.IncludeNameAsync(product.Name))
                return BadRequest($"Товар с именем {product.Name} уже существует");

            await _unitOfWork.Products.CreateForCategoryAsync(categoryId, resultProduct);
            await _unitOfWork.Save();
            var returnProduct = _mapper.Map<ProductDTO>(resultProduct);

            return CreatedAtRoute("GetProduct", new
            {
                categoryId = returnProduct.CategoryId,
                productId = resultProduct.Id
            },
            returnProduct);

        }
     }
}
