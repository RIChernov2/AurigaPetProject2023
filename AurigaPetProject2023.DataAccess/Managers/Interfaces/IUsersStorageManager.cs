using AurigaPetProject2023.DataAccess.Entities;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Managers.Interfaces
{
    public interface IUsersStorageManager
    {
        //Task<int> CreateAsync(TEntity entity);
        //Task<IReadOnlyList<User>> GetAsync();
        Task<User> GetAsync(int id);
        //Task<IReadOnlyList<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate);
        ////Task <IReadOnlyList<TEntity>> GetAsync(IEnumerable<Targ> ids);
        //Task<int> UpdateAsync(TEntity entity);
        //Task<int> DeleteAsync(Targ id);
    }
}
