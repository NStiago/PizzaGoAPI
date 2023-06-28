using PizzaGoAPI.Entities;

namespace PizzaGoAPI.DataAccess.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<int> GetCountProductFromCategory(int categoryId);
        Task<IEnumerable<Product>> GetProductsOfCategory(int categoryId);
    }
}
