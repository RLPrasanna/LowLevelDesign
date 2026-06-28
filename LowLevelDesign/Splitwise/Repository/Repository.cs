using Microsoft.EntityFrameworkCore;

namespace Splitwise.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDBContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual T GetById(long id) => _dbSet.Find(id);

        public virtual IEnumerable<T> GetAll() => _dbSet.ToList();

        public virtual T Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity; // return persisted entity
        }

        public virtual T Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity; // return updated entity
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            _context.SaveChanges();
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}
