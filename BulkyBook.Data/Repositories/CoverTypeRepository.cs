using BulkyBook.Data.Contexts;
using BulkyBook.Data.IRepositories;
using BulkyBook.Models;

namespace BulkyBook.Data.Repositories
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly BulkyBookContext _context;

        public CoverTypeRepository(BulkyBookContext context) : base(context)
        {
            _context = context;
        }

        public void Update(CoverType coverType)
        {
            _context.CoverTypes.Update(coverType);
        }
    }
}
