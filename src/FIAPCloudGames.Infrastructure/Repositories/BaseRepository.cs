using FIAPCloudGames.Domain.Repositores;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FIAPCloudGames.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected DbSet<TEntity> _dbSet;

    public BaseRepository(DbContext dbContext, CancellationToken cancellationToken = default)
        => _dbSet = dbContext.Set<TEntity>();

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(entity);

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await Task.Run(() =>
        {
            _dbSet.Update(entity);
        });

    public void Delete(TEntity entity, CancellationToken cancellationToken = default)
        => _dbSet.Remove(entity);

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await Task.Run(() => { Delete(entity); });

    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(predicate);

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        if (predicate is null)
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        if (predicate is null)
            return await _dbSet.CountAsync(cancellationToken);
        return await _dbSet.CountAsync(predicate, cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }
}
