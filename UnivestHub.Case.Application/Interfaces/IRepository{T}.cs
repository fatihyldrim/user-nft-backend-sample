using System.Linq.Expressions;

namespace UnivestHub.Case.Application.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class, new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> filter);
        Task CreateAsync(TEntity entity);
        void Remove(TEntity entity);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter);
    }
}
