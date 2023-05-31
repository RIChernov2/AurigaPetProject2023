using AurigaPetProject2023.DataAccess.Entities;

namespace AurigaPetProject2023.DataAccess.Managers.Interfaces
{
    public interface IRentInfoStorageManager
    {
        int Create(RentInfo entity);
        int Update(RentInfo entity);
    }
}
