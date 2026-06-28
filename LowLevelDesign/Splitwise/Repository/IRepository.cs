namespace Splitwise.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(long id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void SaveChanges();
    }
}
