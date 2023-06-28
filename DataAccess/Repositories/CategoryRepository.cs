using Microsoft.EntityFrameworkCore;
using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.DBContext;
using PizzaGoAPI.Entities;

namespace PizzaGoAPI.DataAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(PizzaAppContext context) : base(context) 
        {
            
        }

        public async Task<Category?> GetAsync(int id, bool includeProduct)
        {
            if (includeProduct)
            {
                return await _context.Categories.Include(x=>x.Products).Where(p=> p.Id == id).FirstOrDefaultAsync();
            }
            return await _context.Categories.Where(p=> p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<bool> CategoryExistAsync(int categoryId)
        {
            return await _context.Categories.AnyAsync(x=>x.Id == categoryId);
        }
    }
}
