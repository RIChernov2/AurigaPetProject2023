using AurigaPetProject2023.DataAccess.Entities;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IRepairingInfoRepository
    {
        Task<int> CreateAsync(RepairingInfo entity);
        Task<int> UpdateAsync(RepairingInfo entity);
    }
}
