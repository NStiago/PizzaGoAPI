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
        public async Task<IEnumerable<Product>> GetProductsOfCategory(int categoryId, int? cheaperThan)
        {
            if(!cheaperThan.HasValue) 
            { 
                return await GetProductsOfCategory(categoryId);
            }
            return await _context.Products
                .Where(x => x.CategoryId == categoryId)
                .Where(cost=>cost.Price<=cheaperThan)
                .ToListAsync();
        }
        public async Task<int> GetCountProductFromCategory(int categoryId)
        {
            return await _context.Products.Where(x => x.CategoryId == categoryId).CountAsync();
        }
        public async Task<bool> IncludeNameAsync(string productName)
        {
            return await _context.Products.AnyAsync(x => x.Name == productName);
        }
        //необходимо доработать
        public async Task CreateForCategoryAsync(int categoryId, Product product)
        {
            var category = await _context.Categories.Include(p=>p.Products).Where(x=>x.Id==categoryId).FirstOrDefaultAsync();
            if(category != null)
            {
                category.Products.Add(product);
            }
        }
    }
}
