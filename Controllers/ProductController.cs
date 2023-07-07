using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.Entities;
using PizzaGoAPI.Models;
using System.Text.Json;

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
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        //Получение продуктов категории, с использованием фильтрации по стоимости c функцией поиска по имени и описанию
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts(int categoryId, string? cheaperThan, string? searchString)
        {
            if (!await _unitOfWork.Categories.CategoryExistAsync(categoryId))
            {
                _logger.LogInformation($"Category with Id: {categoryId} Not Found");
                return NotFound();
            }
            _logger.LogInformation($"Get a count of Product: {await _unitOfWork.Products.GetCountProductFromCategory(categoryId)} " +
                $"from Category {categoryId}");
            var productsToReturn = await _unitOfWork.Products.GetProductsOfCategory(categoryId,cheaperThan,searchString);
            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(productsToReturn));
        }

        [HttpGet("{productId}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int categoryId, int productId)
        {
            if (!await _unitOfWork.Categories.CategoryExistAsync(categoryId))
            {
                _logger.LogInformation($"Category with Id: {categoryId} Not Found");
                return NotFound();
            }
            var productToReturn = await _unitOfWork.Products.GetAsync(productId);
            if (productToReturn == null)
            {
                _logger.LogInformation($"Product with Id: {productId} Not Found");
                return NotFound();
            }
            _logger.LogInformation($"Get a Product {productId} from {categoryId}");
            return Ok(_mapper.Map<ProductDTO>(productToReturn));
        }

        [HttpPost]
        [Authorize]
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
            _logger.LogInformation($"Create a Product with ID: {returnProduct.Id}");
            return CreatedAtRoute("GetProduct", new
            {
                categoryId = returnProduct.CategoryId,
                productId = resultProduct.Id
            },
            returnProduct);
        }

        [HttpPut("{productId}")]
        [Authorize]
        public async Task<ActionResult> UpdateProduct(int categoryId, int productId, ProductDTOForCreation inputProduct)
        {
            if (!await _unitOfWork.Categories.CategoryExistAsync(categoryId))
            {
                _logger.LogInformation($"Category with Id: {categoryId} Not Found");
                return NotFound();
            }
            var productForUpdate = await _unitOfWork.Products.GetAsync(productId);
            if (productForUpdate == null)
            {
                _logger.LogInformation($"Product with Id: {productId} Not Found");
                return NotFound();
            }
            _mapper.Map(inputProduct, productForUpdate);
            _logger.LogInformation($"Update a Product with ID: {productForUpdate.Id}");
            await _unitOfWork.Save();
            return NoContent();
        }

        [HttpPatch("{productId}")]
        [Authorize]
        public async Task<ActionResult> PartiallyUpdateProduct(int categoryId, int productId,
            JsonPatchDocument<ProductDTOForCreation> inputJsonPatch)
        {
            if (!await _unitOfWork.Categories.CategoryExistAsync(categoryId))
            {
                _logger.LogInformation($"Category with Id: {categoryId} Not Found");
                return NotFound();
            }
            var productFromDB = await _unitOfWork.Products.GetAsync(productId);
            if (productFromDB == null)
            {
                _logger.LogInformation($"Product with Id: {productId} Not Found");
                return NotFound();
            }

            var productForPatch = _mapper.Map<ProductDTOForCreation>(productFromDB);
            inputJsonPatch.ApplyTo(productForPatch);

            _mapper.Map(productForPatch, productFromDB);
            _logger.LogInformation($"Update a Product with ID: {productFromDB.Id}");
            await _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{productId}")]
        [Authorize]
        public async Task<ActionResult> DeleteProduct(int categoryId, int productId)
        {
            if (!await _unitOfWork.Categories.CategoryExistAsync(categoryId))
            {
                _logger.LogInformation($"Category with Id: {categoryId} Not Found");
                return NotFound();
            }
            var productForDelete = _unitOfWork.Products.Get(productId);
            if (productForDelete == null)
            {
                _logger.LogInformation($"Product with Id: {productId} Not Found");
                return NotFound();
            }
            _unitOfWork.Products.Delete(productId);
            await _unitOfWork.Save();
            _logger.LogInformation($"Delete a Product with ID: {productId}");
            return NoContent();
        }
    }
}
