using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Xml;
using AurigaPetProject2023.DataAccess.Dto;

namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class ItemRepository : IItemRepository
    {
        private DbContext _context;
        private DbSet<Item> _dbSet;

        public ItemRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Item>();
        }

        public virtual async Task<int> CreateAsync(Item entity)
        {
            await _dbSet.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public virtual async Task<int> CreateUniqueIdAsync(int itemID)
        {
            DbSet<ItemUniqueInfo> dbSet = _context.Set<ItemUniqueInfo>();
            await dbSet.AddAsync(new ItemUniqueInfo() { ItemID = itemID });

            return await _context.SaveChangesAsync();
        }
        public virtual int GetLastId()
        {
            NewContext context = (NewContext)_context;
            return context.Items.Select(x => x.ItemID).OrderBy(x => x).Last();

        }        
        public async Task<IReadOnlyList<Item>> GetAvailiableAsync()
        {
            return await (from item in _context.Set<Item>()
                         join itemType in _context.Set<ItemType>() on item.ItemTypeID equals itemType.ItemTypeID
                         join itemUniqueInfo in _context.Set<ItemUniqueInfo>() on item.ItemID equals itemUniqueInfo.ItemID into uniqueInfoGroup
                         from uniqueInfo in uniqueInfoGroup.DefaultIfEmpty()

                         where !_context.Set<DisabledInfo>().Any(x => x.ItemID == item.ItemID)
                         && !_context.Set<RepairingInfo>().Where(x => x.EndDate == null).Any(x => x.ItemID == item.ItemID)
                         && !_context.Set<RentInfo>().Where(x=> x.EndDate == null).Any(x => x.ItemID == item.ItemID)

                          select new Item
                            {
                                ItemID = item.ItemID,
                                ItemTypeID = item.ItemTypeID,
                                Description = item.Description,
                                ItemType = itemType,
                                UniqueID = !itemType.IsUnique ? null : uniqueInfo.ItemUniqueID
                            }).ToListAsync();
        }
        public async Task<IReadOnlyList<ItemWithDisableInfo>> GetDisabledAsync()
        {
            return await (from item in _context.Set<Item>()
                          join itemType in _context.Set<ItemType>() on item.ItemTypeID equals itemType.ItemTypeID
                          join itemUniqueInfo in _context.Set<ItemUniqueInfo>() on item.ItemID equals itemUniqueInfo.ItemID into uniqueInfoGroup
                          from uniqueInfo in uniqueInfoGroup.DefaultIfEmpty()
                          join disabled in _context.Set<DisabledInfo>() on item.ItemID equals disabled.ItemID


                          select new ItemWithDisableInfo()
                          {
                              ItemData = new Item()
                              {
                                  ItemID = item.ItemID,
                                  ItemTypeID = item.ItemTypeID,
                                  Description = item.Description,
                                  ItemType = itemType,
                                  UniqueID = !itemType.IsUnique ? null : uniqueInfo.ItemUniqueID
                              },

                              DisabledInfoData = disabled
                          }).ToListAsync();
        }
        public async Task<IReadOnlyList<ItemWithRepairingInfoInfo>> GetRepairingAsync()
        {
            return await (from item in _context.Set<Item>()
                          join itemType in _context.Set<ItemType>() on item.ItemTypeID equals itemType.ItemTypeID
                          join itemUniqueInfo in _context.Set<ItemUniqueInfo>() on item.ItemID equals itemUniqueInfo.ItemID into uniqueInfoGroup
                          from uniqueInfo in uniqueInfoGroup.DefaultIfEmpty()
                          join repairing in _context.Set<RepairingInfo>() on item.ItemID equals repairing.ItemID
                          where repairing.EndDate == null

                          //where _context.Set<RepairingInfo>().Any(x => x.ItemID == item.ItemID)
                          select new ItemWithRepairingInfoInfo
                          {
                              ItemData = new Item()
                              {
                                  ItemID = item.ItemID,
                                  ItemTypeID = item.ItemTypeID,
                                  Description = item.Description,
                                  ItemType = itemType,
                                  UniqueID = !itemType.IsUnique ? null : uniqueInfo.ItemUniqueID
                              },
                              RepairingInfoData = repairing
                          }).ToListAsync();
        }
        public async Task<IReadOnlyList<ItemWithRentInfo>> GetInRentAsync()
        {
            return await (from item in _context.Set<Item>()
                          join itemType in _context.Set<ItemType>() on item.ItemTypeID equals itemType.ItemTypeID
                          join itemUniqueInfo in _context.Set<ItemUniqueInfo>() on item.ItemID equals itemUniqueInfo.ItemID into uniqueInfoGroup
                          from uniqueInfo in uniqueInfoGroup.DefaultIfEmpty()

                          join rent in _context.Set<RentInfo>() on item.ItemID equals rent.ItemID
                          where rent.EndDate == null

                          select new ItemWithRentInfo
                          {
                              ItemData = new Item()
                              {
                                  ItemID = item.ItemID,
                                  ItemTypeID = item.ItemTypeID,
                                  Description = item.Description,
                                  ItemType = itemType,
                                  UniqueID = !itemType.IsUnique ? null : uniqueInfo.ItemUniqueID
                              },
                              RentInfo = rent
                          }).ToListAsync();
        }

    }
}
