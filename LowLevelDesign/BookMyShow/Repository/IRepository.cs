using System.Linq.Expressions;

namespace BookMyShow.Repository
{
    public interface IRepository<T> where T:class
    {
        T GetFirstorDefault(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        T GetById(long id);
        T Add(T entity);
        T Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        void SaveChanges();
    }
}
