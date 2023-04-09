using BulkyBook.Data.Contexts;
using BulkyBook.Data.IRepositories;

namespace BulkyBook.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Categories { get; private set; }
        public ICoverTypeRepository CoverTypes { get; private set; }
        public IProductRepository Products { get; private set; }

        private readonly BulkyBookContext _context;

        public UnitOfWork(BulkyBookContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            CoverTypes = new CoverTypeRepository(_context);
            Products = new ProductRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
