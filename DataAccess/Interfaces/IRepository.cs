namespace PizzaGoAPI.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Get(int id);
        Task<T?> GetAsync(int id);
        void Create(T entity);
        void CreateAsync(T entity);
        void Update(T entity);
        void UpdateAsync(T entity);
        void Delete(int id);
        void DeleteAsync(int id);
    }
}
