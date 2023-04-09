using BulkyBook.Data.Contexts;
using BulkyBook.Data.IRepositories;
using BulkyBook.Models;

namespace BulkyBook.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly BulkyBookContext _context;

        public ProductRepository(BulkyBookContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var entity = _context.Products.FirstOrDefault(p => p.Id == product.Id);

            if (entity != null)
            {
                entity.Title = product.Title;
                entity.Description = product.Description;
                entity.ISBN = product.ISBN;
                entity.Author = product.Author;
                entity.ListPrice = product.ListPrice;
                entity.Price50 = product.Price50;
                entity.Price100 = product.Price100;
                entity.CategoryId = product.CategoryId;
                entity.CoverTypeId = product.CoverTypeId;

                if (product.ImgUrl != null)
                    entity.ImgUrl = product.ImgUrl;
            }
        }
    }
}
