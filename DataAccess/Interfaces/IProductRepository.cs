using PizzaGoAPI.Entities;

namespace PizzaGoAPI.DataAccess.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task CreateForCategoryAsync(int categoryId, Product product);
        Task<int> GetCountProductFromCategory(int categoryId);
        Task<IEnumerable<Product>> GetProductsOfCategory(int categoryId);
        Task<bool> IncludeNameAsync(string productName);
    }
}
