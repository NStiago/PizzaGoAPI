using PizzaGoAPI.Entities;

namespace PizzaGoAPI.DataAccess.Interfaces
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<Category?> GetAsync(int id, bool includeProduct);
    }
}
