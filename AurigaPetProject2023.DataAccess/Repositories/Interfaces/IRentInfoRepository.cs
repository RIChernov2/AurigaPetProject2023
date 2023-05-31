using AurigaPetProject2023.DataAccess.Entities;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IRentInfoRepository
    {
        Task<int> CreateAsync(RentInfo entity);
        Task<int> UpdateAsync(RentInfo entity);
    }

}
