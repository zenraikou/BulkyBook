using BulkyBook.Data.Contexts;
using BulkyBook.Data.IRepositories;
using BulkyBook.Models;

namespace BulkyBook.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly BulkyBookContext _context;

        public CategoryRepository(BulkyBookContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
