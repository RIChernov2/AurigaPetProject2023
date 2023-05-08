using AurigaPetProject2023.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Managers.Interfaces
{
    public interface IItemTypesStorageManager
    {
        Task<List<ItemType>> GetAllAsync();
        List<ItemType> GetAll();
        int Create(ItemType entity);
        int Update(ItemType entity);
        int Delete(int id);
    }
}
