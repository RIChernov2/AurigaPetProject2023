using AurigaPetProject2023.DataAccess.Entities;
using System.Collections.Generic;


namespace AurigaPetProject2023.DataAccess.Managers.Interfaces
{
    public interface IItemStorageManager
    {
        List<Item> GetDisabled();
        List<Item> GetAvailiable();
        int Create(Item entity);

        // зачем
        //List<Item> GetAll();
        //List<ItemWithStatus> GetItemsWithStatus();
    }
}
