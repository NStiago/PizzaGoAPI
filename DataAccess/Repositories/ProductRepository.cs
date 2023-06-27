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


    }
}
