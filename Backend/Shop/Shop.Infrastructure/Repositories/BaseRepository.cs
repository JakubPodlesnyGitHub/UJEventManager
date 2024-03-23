using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Shop.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ShopDbContext _shopDbContext;
        private DbSet<TEntity> _dbSet;

        public BaseRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
            _dbSet = shopDbContext.Set<TEntity>();
        }

        public async Task<TEntity> Delete(object id)
        {
            TEntity? record = await _dbSet.FindAsync(id);
            if (record != null)
            {
                _shopDbContext.Attach(record);
                _shopDbContext.Entry(record).State = EntityState.Deleted;
            }
            return record;
        }

        public async Task<TEntity> Delete(object id1, object id2)
        {
            TEntity? record = await _dbSet.FindAsync(id1, id2);
            if (record != null)
            {
                _shopDbContext.Attach(record);
                _shopDbContext.Entry(record).State = EntityState.Deleted;
            }
            return record;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(object id)
        {
            TEntity? record = await _dbSet.FindAsync(id);
            return record;
        }

        public async Task<TEntity> GetById(object id1, object id2)
        {
            TEntity? record = await _dbSet.FindAsync(id1, id2);
            return record;
        }

        public async Task<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity? record = await _dbSet.Where(predicate).FirstOrDefaultAsync();
            return record;
        }

        public async Task<List<TEntity>> GetAllBySpecificData(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public TEntity Insert(TEntity record)
        {
            _shopDbContext.Attach(record);
            _shopDbContext.Entry(record).State = EntityState.Added;
            return record;
        }

        public TEntity Update(TEntity record)
        {
            _shopDbContext.Attach(record);
            _shopDbContext.Entry(record).State = EntityState.Modified;
            return record;
        }
    }
}
