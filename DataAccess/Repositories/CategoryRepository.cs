using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.DBContext;
using PizzaGoAPI.Entities;

namespace PizzaGoAPI.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private PizzaAppContext _context;
        public CategoryRepository(PizzaAppContext context) : base(context)
        {
            _context = context;
        }
    }
}
