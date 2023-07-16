using AurigaPetProject2023.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IRepairingInfoRepository
    {
        Task<int> CreateAsync(RepairingInfo entity);
        Task<int> UpdateAsync(RepairingInfo entity);
        // создаем метод для проведения тестов
        Task<IReadOnlyList<RepairingInfo>> GetAsync();
    }
}
