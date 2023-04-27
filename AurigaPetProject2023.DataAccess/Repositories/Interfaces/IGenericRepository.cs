using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity, TArg> where TEntity : class
    {
        Task <int> CreateAsync(TEntity entity);
        Task <IReadOnlyList<TEntity>> GetAsync();
        Task<TEntity> GetAsync(TArg id);
        Task<IReadOnlyList<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate);
        //// ТЕСТ
        //Task <IReadOnlyList<TEntity>> GetAsync(IEnumerable<TArg> ids);
        Task <int> UpdateAsync(TEntity entity);
        Task <int> DeleteAsync(TArg id);
    }
}
