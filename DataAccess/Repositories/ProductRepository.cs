using Microsoft.EntityFrameworkCore;
using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.DBContext;
using PizzaGoAPI.Entities;

namespace PizzaGoAPI.DataAccess.Repositories
{
    public class ProductRepository :  GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(PizzaAppContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Product>> GetProductsOfCategory(int categoryId)
        {
            return await _context.Products.Where(x=>x.CategoryId==categoryId).ToListAsync();
        }
        public async Task<int> GetCountProductFromCategory(int categoryId)
        {
            return await _context.Products.Where(x => x.CategoryId == categoryId).CountAsync();
        }
    }
}
