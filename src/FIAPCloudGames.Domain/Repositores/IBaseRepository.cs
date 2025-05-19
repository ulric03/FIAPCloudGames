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

    Task<TEntity> GetByIdAsync(int id, IEnumerable<string>? entitiesToInclude = null);

    Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<Expression<Func<TEntity, bool>>>? predicates = null, IEnumerable<string>? entitiesToInclude = null);

    Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);

    void Delete(TEntity entity);

    Task DeleteAsync(TEntity entity);
}
