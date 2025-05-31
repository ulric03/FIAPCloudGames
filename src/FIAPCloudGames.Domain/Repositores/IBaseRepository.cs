using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.Repositores;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predicate);

    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

    Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);

    void Delete(TEntity entity);

    Task DeleteAsync(TEntity entity);
}
