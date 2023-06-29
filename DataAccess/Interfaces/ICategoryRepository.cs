using PizzaGoAPI.Entities;

namespace PizzaGoAPI.DataAccess.Interfaces
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<bool> IncludeNameAsync(string categoryName);
        Task<bool> CategoryExistAsync(int categoryId);
        Task<Category?> GetAsync(int id, bool includeProduct);
    }
}
