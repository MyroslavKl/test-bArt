using System.Linq.Expressions;
using Application.Contracts.Common;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Common;

public class Repository<TEntity>:IRepository<TEntity> where TEntity:class
{
    private readonly TaskDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(TaskDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();

    }

    public async Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if (filter is not null)
        {
            query = query.Where(filter);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}