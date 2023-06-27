using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.DBContext;

namespace PizzaGoAPI.DataAccess.Repositories
{
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        private readonly PizzaAppContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(PizzaAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            IQueryable<T> query = _dbSet;
            if (include is not null)
            {
                query = include(query);
            }
            if (orderBy is not null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();

        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T?> GetAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
