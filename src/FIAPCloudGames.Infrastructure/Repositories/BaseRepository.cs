using FIAPCloudGames.Domain.Repositores;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FIAPCloudGames.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class 
{
    protected DbSet<TEntity> _dbSet;

    public BaseRepository(DbContext dbContext)
        => _dbSet = dbContext.Set<TEntity>();

    public async Task AddAsync(TEntity entity)
        => await _dbSet.AddAsync(entity);

    public async Task UpdateAsync(TEntity entity)
        => await Task.Run(() => { _dbSet.Update(entity); });

    public void Delete(TEntity entity) 
        => _dbSet.Remove(entity);

    public async Task DeleteAsync(TEntity entity)
        => await Task.Run(() => { Delete(entity); });

    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate)
        => await _dbSet.AnyAsync(predicate);

    public async Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<Expression<Func<TEntity, bool>>>? predicates = null, IEnumerable<string>? entitiesToInclude = null)
    {
        //return await _entities
        //    .Where(predicates)
        //    .Include(entitiesToInclude)
        //    .ToListAsync();

        return null;
    }

    public async Task<TEntity> GetByIdAsync(int id, IEnumerable<string>? entitiesToInclude = null)
    {
        //return await _entities
        //    .Include(entitiesToInclude)
        //    .FirstOrDefaultAsync(e => e.Id == id);
        return null;
    }
}
