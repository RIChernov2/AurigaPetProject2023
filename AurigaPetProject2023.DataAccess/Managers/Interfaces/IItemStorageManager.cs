using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Entities;
using System.Collections.Generic;


namespace AurigaPetProject2023.DataAccess.Managers.Interfaces
{
    public interface IItemStorageManager
    {
        List<ItemWithDisableInfo> GetDisabled();
        List<ItemWithRepairingInfoInfo> GetRepairing();
        List<ItemWithRentInfo> GetInRent();
        List<Item> GetAvailiable();
        int Create(Item entity);

    }
}
