using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.DBContext;
using PizzaGoAPI.Entities;

namespace PizzaGoAPI.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private PizzaAppContext _context;
        public ProductRepository(PizzaAppContext context) : base(context)
        {
            _context = context;
        }
    }
}
