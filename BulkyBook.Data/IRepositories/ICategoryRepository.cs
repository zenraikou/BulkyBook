using BulkyBook.Models;

namespace BulkyBook.Data.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
