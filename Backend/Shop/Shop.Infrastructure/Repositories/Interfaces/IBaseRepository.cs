using System.Linq.Expressions;

namespace Shop.Infrastructure.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<List<TEntity>> GetAllBySpecificData(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity> GetById(object id);

        Task<TEntity> GetById(object id1, object id2);

        Task<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);

        TEntity Insert(TEntity record);

        TEntity Update(TEntity record);

        Task<TEntity> Delete(object id);

        Task<TEntity> Delete(object id1, object id2);
        Task Commit();
    }
}