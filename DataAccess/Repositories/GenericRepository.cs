using Microsoft.EntityFrameworkCore;
using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.DBContext;

namespace PizzaGoAPI.DataAccess.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PizzaAppContext _context;
        public GenericRepository(PizzaAppContext context)
        {
            _context=context;
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task CreateAsync(T entity)
        {
            if(entity != null)
               await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(int id)
        {
            var entityForDeleting = Get(id);
            if (entityForDeleting != null)
                _context.Set<T>().Remove(entityForDeleting);
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }
    }
}
