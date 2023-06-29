using Microsoft.EntityFrameworkCore.Query;

namespace PizzaGoAPI.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);
        Task<T> GetAsync(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        void Create(T entity);
        //возможно придется вернуть Task<int>
        Task CreateAsync(T entity);
        void Update(T entity);
        //возможно придется вернуть Task<int>
        Task<int> GetCountAsync();
        void Delete(int id);
    }
}
