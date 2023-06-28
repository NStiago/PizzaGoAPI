using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaGoAPI.DataAccess.Interfaces;
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

        [HttpGet("{productId}")]
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
                _logger.LogInformation($"CProduct with Id: {productId} Not Found");
                return NotFound();
            }
            _logger.LogInformation($"Get a Product {productId} from {categoryId}");
            return Ok(_mapper.Map<ProductDTO>(productToReturn));
        }
     }
}
