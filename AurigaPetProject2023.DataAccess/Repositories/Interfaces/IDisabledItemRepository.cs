using AurigaPetProject2023.DataAccess.Entities;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IDisabledItemRepository
    {
        Task<int> CreateAsync(DisabledInfo entity);
    }
}
