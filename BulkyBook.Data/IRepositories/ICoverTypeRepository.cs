using BulkyBook.Models;

namespace BulkyBook.Data.IRepositories
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType coverType);
    }
}
