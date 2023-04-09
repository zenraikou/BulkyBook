using System.Linq.Expressions;

namespace BulkyBook.Data.IRepositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List();
        void Create(T entity);
        T Read(int id);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        T GetFirstOrDefault(Expression<Func<T, bool>> expression);
    }
}
