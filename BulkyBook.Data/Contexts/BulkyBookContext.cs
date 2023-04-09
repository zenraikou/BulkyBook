using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Data.Contexts
{
    public class BulkyBookContext : DbContext
    {
        public BulkyBookContext(DbContextOptions<BulkyBookContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
