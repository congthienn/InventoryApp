using InventoryApp.Infrastructures.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace InventoryApp.Infrastructures.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        private DbSet<TEntity> _dbSet;
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _context = (DbContext)unitOfWork.Context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public async Task Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
                _dbSet.Attach(entityToDelete);
            _dbSet.Remove(entityToDelete);
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
                return orderBy(query).ToList();
            return query.ToList();
        }

        public async Task<TEntity> GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public async Task Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async Task Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
