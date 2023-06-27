using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.DBContext;

namespace PizzaGoAPI.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PizzaAppContext _context;
        private bool disposed = false;
        public ICategoryRepository Categories { get;  }
        public IProductRepository Products { get; }

        public UnitOfWork(PizzaAppContext context, ICategoryRepository categories, IProductRepository products)
        {
            _context = context;
            Categories = categories;
            Products = products;
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
