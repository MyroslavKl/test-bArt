using System.Linq.Expressions;

namespace Application.Contracts.Common;

public interface IRepository<TEntity> where TEntity:class
{
    Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    Task SaveChangesAsync();
}