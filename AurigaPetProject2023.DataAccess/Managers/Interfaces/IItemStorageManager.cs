using AurigaPetProject2023.DataAccess.Entities;
using System.Collections.Generic;


namespace AurigaPetProject2023.DataAccess.Managers.Interfaces
{
    public interface IItemStorageManager
    {
        List<Item> GetAll();
        int Create(Item entity);
    }
}
