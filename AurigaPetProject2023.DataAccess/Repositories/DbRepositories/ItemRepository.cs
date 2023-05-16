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
        //// зачем?
        //public virtual async Task<IReadOnlyList<Item>> GetAsync()
        //{

        //    return await (from items in _context.Set<Item>()
        //                  join types in _context.Set<ItemType>()
        //                  on items.ItemTypeID equals types.ItemTypeID

        //                  join uniqueIds in _context.Set<ItemUniqueInfo>()
        //                  on items.ItemID equals uniqueIds.ItemID into T2

        //                  from uniqueNumber in T2.DefaultIfEmpty()

        //                  select new Item()
        //                  {
        //                      ItemID = items.ItemID,
        //                      ItemTypeID = items.ItemTypeID,
        //                      Description = items.Description,
        //                      ItemType = types,
        //                      UniqueID = !types.IsUnique ? null : uniqueNumber.ItemUniqueID
        //                  }).ToListAsync();
        //}
        //// зачем?
        //public virtual async Task<IReadOnlyList<ItemWithStatus>> GetItemsWithStatusAsync()
        //{
        //    return await (      from item in _context.Set<Item>()
        //                        join itemType in _context.Set<ItemType>() on item.ItemTypeID equals itemType.ItemTypeID
        //                        join itemUniqueInfo in _context.Set<ItemUniqueInfo>() on item.ItemID equals itemUniqueInfo.ItemID into uniqueInfoGroup
        //                        from uniqueInfo in uniqueInfoGroup.DefaultIfEmpty()
        //                        join disabledInfo in _context.Set<DisabledInfo>()on item.ItemID equals disabledInfo.ItemID into disabledInfoGroup
        //                        from disabledInfo in disabledInfoGroup.DefaultIfEmpty()

        //                        join rentInfo in _context.Set<RentInfo>() on item.ItemID equals rentInfo.ItemID into rentInfoGroup
        //                        from rentInfo in rentInfoGroup.DefaultIfEmpty()

        //                        join repairtInfo in _context.Set<RepairingInfo>() on item.ItemID equals repairtInfo.ItemID into repairingtInfoGroup
        //                        from repairtInfo in repairingtInfoGroup.DefaultIfEmpty()

        //                        select new ItemWithStatus()
        //                        {
        //                            ItemID = item.ItemID,
        //                            ItemTypeID = item.ItemTypeID,
        //                            Description = item.Description,
        //                            ItemType = itemType,
        //                            UniqueID = !itemType.IsUnique ? null : uniqueInfo.ItemUniqueID,
        //                            Disabled = disabledInfo == null ? false : true,
        //                            InRent = rentInfo != null && rentInfo.EndtDate == null,
        //                            InRepair = repairtInfo != null && repairtInfo.EndtDate == null


        //                            //ItemType = types,
        //                        }).ToListAsync();
        //}

        public async Task<IReadOnlyList<Item>> GetAvailiableAsync()
        {
            return await (from item in _context.Set<Item>()
                         join itemType in _context.Set<ItemType>() on item.ItemTypeID equals itemType.ItemTypeID
                         join itemUniqueInfo in _context.Set<ItemUniqueInfo>() on item.ItemID equals itemUniqueInfo.ItemID into uniqueInfoGroup
                         from uniqueInfo in uniqueInfoGroup.DefaultIfEmpty()

                         where !_context.Set<DisabledInfo>().Any(x => x.ItemID == item.ItemID)
                         && !_context.Set<RepairingInfo>().Where(x => x.EndtDate != null).Any(x => x.ItemID == item.ItemID)
                         && !_context.Set<RentInfo>().Where(x=> x.EndtDate != null).Any(x => x.ItemID == item.ItemID)

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
                          //where _context.Set<DisabledInfo>().Any(x => x.ItemID == item.ItemID)

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
        //public async Task<IReadOnlyList<Item>> GetDisabledAsync()  
        //{
        //    return await (from item in _context.Set<Item>()
        //                  join itemType in _context.Set<ItemType>() on item.ItemTypeID equals itemType.ItemTypeID
        //                  join itemUniqueInfo in _context.Set<ItemUniqueInfo>() on item.ItemID equals itemUniqueInfo.ItemID into uniqueInfoGroup
        //                  from uniqueInfo in uniqueInfoGroup.DefaultIfEmpty()

        //                  where _context.Set<DisabledInfo>().Any(x => x.ItemID == item.ItemID)
        //                  select new Item
        //                  {
        //                      ItemID = item.ItemID,
        //                      ItemTypeID = item.ItemTypeID,
        //                      Description = item.Description,
        //                      ItemType = itemType,
        //                      UniqueID = !itemType.IsUnique ? null : uniqueInfo.ItemUniqueID
        //                  }).ToListAsync();
        //}

        public async Task<IReadOnlyList<Item>> GetRepairingAsync()
        {
            return await (from item in _context.Set<Item>()
                          join itemType in _context.Set<ItemType>() on item.ItemTypeID equals itemType.ItemTypeID
                          join itemUniqueInfo in _context.Set<ItemUniqueInfo>() on item.ItemID equals itemUniqueInfo.ItemID into uniqueInfoGroup
                          from uniqueInfo in uniqueInfoGroup.DefaultIfEmpty()

                          where _context.Set<RepairingInfo>().Any(x => x.ItemID == item.ItemID)
                          select new Item
                          {
                              ItemID = item.ItemID,
                              ItemTypeID = item.ItemTypeID,
                              Description = item.Description,
                              ItemType = itemType,
                              UniqueID = !itemType.IsUnique ? null : uniqueInfo.ItemUniqueID
                          }).ToListAsync();
        }





        //public async Task<IReadOnlyList<Item>> GetNotDisabledAsync()
        //{
        //    //попробуем иначе
        //    NewContext context = (NewContext)_context;
        //    return await context.Items
        //        .Where(x => !context.DisabledInfos.Select(y => y.ItemID).Contains(x.ItemID))
        //        .Include(item => item.ItemType).ToListAsync();
        //}

        //public async Task<IReadOnlyList<Item>> GetDisabledAsync()
        //{
        //    //попробуем иначе
        //    NewContext context = (NewContext)_context;
        //    return await context.Items
        //        .Where(x => context.DisabledInfos.Select(y => y.ItemID).Contains(x.ItemID))
        //        .Include(item => item.ItemType).ToListAsync();
        //}
    }
}
