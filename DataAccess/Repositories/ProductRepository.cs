using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<IEnumerable<Product>> GetProductsOfCategory(int categoryId, string? cheaperThan, string? searchString)
        {
            if(string.IsNullOrEmpty(cheaperThan) && string.IsNullOrEmpty(searchString)) 
            { 
                return await GetProductsOfCategory(categoryId);
            }
            
            var collection = _context.Products as IQueryable<Product>;
            collection = collection.Where(x => x.CategoryId == categoryId);
            if (!string.IsNullOrWhiteSpace(cheaperThan))
            {
                cheaperThan = cheaperThan.Trim();
                collection = collection.Where(cost => cost.Price <= Convert.ToInt32(cheaperThan));
            }

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.Trim().ToLower();
                collection = collection.Where(srch=>
                                                    srch.Name.ToLower().Contains(searchString)||
                                                    srch.Description.ToLower().Contains(searchString));
            }
            
            return await collection.ToListAsync();
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
