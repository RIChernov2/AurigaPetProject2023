using System.Collections.Generic;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity, Targ> where TEntity : class
    {
        Task <int> CreateAsync(TEntity entity);
        Task <IReadOnlyList<TEntity>> GetAsync();
        //Task <IReadOnlyList<TEntity>> GetAsync(IEnumerable<Targ> ids);
        Task<TEntity> GetAsync(Targ id);
        Task <int> UpdateAsync(TEntity entity);
        Task <int> DeleteAsync(Targ id);
    }
}
