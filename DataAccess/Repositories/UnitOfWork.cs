using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.DBContext;

namespace PizzaGoAPI.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PizzaAppContext _context;
        private bool disposed = false;
        public UnitOfWork(PizzaAppContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
