using AurigaPetProject2023.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IItemtRepository
    {
        Task<int> CreateAsync(Item entity);
        int GetLastId();
        Task<int> CreateUniqueIdAsync(int itemId);

        Task<IReadOnlyList<Item>> GetAvailiableAsync();
        Task<IReadOnlyList<Item>> GetDisabledAsync();

        //Task<IReadOnlyList<Item>> GetRepairingAsync();
        //Task<IReadOnlyList<Item>> GetInRentAsync();

        // зачем?
        //Task<IReadOnlyList<Item>> GetAsync();
        //Task<IReadOnlyList<ItemWithStatus>> GetItemsWithStatusAsync();
    }
}
