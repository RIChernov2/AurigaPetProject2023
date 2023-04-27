using AurigaPetProject2023.DataAccess.Entities;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        Task<IUserLoginResponseInfo> GetUserForLoginAsync(IUserLoginInfo info);
        //Task<User> GetUserForLoginAsync(IUserLoginInfo info);
    }
}


//Task<int> CreateAsync(TEntity entity);
//Task<IReadOnlyList<TEntity>> GetAsync();
//Task<TEntity> GetAsync(Targ id);
//Task<IReadOnlyList<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate);
////Task <IReadOnlyList<TEntity>> GetAsync(IEnumerable<Targ> ids);
//Task<int> UpdateAsync(TEntity entity);
//Task<int> DeleteAsync(Targ id);
