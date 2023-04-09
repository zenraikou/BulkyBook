using BulkyBook.Data.Contexts;
using BulkyBook.Data.IRepositories;
using System.Linq.Expressions;

namespace BulkyBook.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BulkyBookContext _context;

        public Repository(BulkyBookContext context)
        {
            _context = context;
        }

        public IEnumerable<T> List()
        {
            IQueryable<T> entities = _context.Set<T>();
            return entities.ToList();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T Read(int id)
        {
            var entity = _context.Set<T>().Find(id);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> entities = _context.Set<T>();
            entities = entities.Where(expression);
            return entities.FirstOrDefault();
        }
    }
}
