using AurigaPetProject2023.DataAccess.Entities;

namespace AurigaPetProject2023.DataAccess.Managers.Interfaces
{
    public interface IRepairingInfoStorageManager
    {
        int Create(RepairingInfo entity);
        int Update(RepairingInfo entity);
    }
}
