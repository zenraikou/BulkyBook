using BulkyBook.Models;

namespace BulkyBook.Data.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
