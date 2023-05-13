using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Xml;

namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class ItemRepository : IItemtRepository
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

            //using (NewContext context = NewContext())
            //{
            //    return context.Items.Select(x => x.ItemID).OrderBy(x=>x).Last();
            //}
        }

        public virtual async Task<IReadOnlyList<Item>> GetAsync()
        {

            return await (from items in _context.Set<Item>()
                          join types in _context.Set<ItemType>()
                          on items.ItemTypeID equals types.ItemTypeID

                          join uniqueIds in _context.Set<ItemUniqueInfo>()
                          on items.ItemID equals uniqueIds.ItemID into T2

                          from uniqueNumber in T2.DefaultIfEmpty()

                          select new Item()
                          {
                              ItemID = items.ItemID,
                              ItemTypeID = items.ItemTypeID,
                              Description = items.Description,
                              ItemType = types,
                              UniqueID = !types.IsUnique ? null : uniqueNumber.ItemUniqueID
                              //ItemType = types,
                          }).ToListAsync();
        }

        public virtual async Task<IReadOnlyList<ItemWithStatus>> GetItemsWithStatusAsync()
        {
            //return await (from items in _context.Set<Item>()
            //              join types in _context.Set<ItemType>()
            //              on items.ItemTypeID equals types.ItemTypeID

            //              join uniqueIds in _context.Set<ItemUniqueInfo>()
            //              on items.ItemID equals uniqueIds.ItemID into T2

            //              from uniqueNumber in T2.DefaultIfEmpty()
            //              join disableInfo in _context.Set<DisabledInfo>()
            //              on items.ItemID equals disableInfo.ItemID into T3

            //              from disable in T3.DefaultIfEmpty()
            //              join repairInfo in _context.Set<RepairingInfo>()
            //              //( 
            //              //      from repairInfo in _context.Set<RepairingInfo>()
            //              //      where repairInfo.EndtDate == null
            //              //      )
            //              on items.ItemID equals repairInfo.ItemID into T4

            //              from repair in T4.DefaultIfEmpty()
            //              where repair.EndtDate == null

            //              select new ItemWithStatus()
            //              {
            //                  ItemID = items.ItemID,
            //                  ItemTypeID = items.ItemTypeID,
            //                  Description = items.Description,
            //                  ItemType = types,
            //                  UniqueID = !types.IsUnique ? null : uniqueNumber.ItemUniqueID,
            //                  Disabled = disable == null ? false : true,
            //                  InRepair = repair == null ? false : (repair.EndtDate == null? true: false)


            //                  //ItemType = types,
            //              }).ToListAsync();

            return await (      from item in _context.Set<Item>()
                                join itemType in _context.Set<ItemType>() on item.ItemTypeID equals itemType.ItemTypeID
                                join itemUniqueInfo in _context.Set<ItemUniqueInfo>() on item.ItemID equals itemUniqueInfo.ItemID into uniqueInfoGroup
                                from uniqueInfo in uniqueInfoGroup.DefaultIfEmpty()
                                join disabledInfo in _context.Set<DisabledInfo>()on item.ItemID equals disabledInfo.ItemID into disabledInfoGroup
                                from disabledInfo in disabledInfoGroup.DefaultIfEmpty()

                                join rentInfo in _context.Set<RentInfo>() on item.ItemID equals rentInfo.ItemID into rentInfoGroup
                                from rentInfo in rentInfoGroup.DefaultIfEmpty()

                                join repairtInfo in _context.Set<RepairingInfo>() on item.ItemID equals repairtInfo.ItemID into repairingtInfoGroup
                                from repairtInfo in repairingtInfoGroup.DefaultIfEmpty()

                                select new ItemWithStatus()
                                {
                                    ItemID = item.ItemID,
                                    ItemTypeID = item.ItemTypeID,
                                    Description = item.Description,
                                    ItemType = itemType,
                                    UniqueID = !itemType.IsUnique ? null : uniqueInfo.ItemUniqueID,
                                    Disabled = disabledInfo == null ? false : true,
                                    InRent = rentInfo != null && rentInfo.EndtDate == null,
                                    InRepair = repairtInfo != null && repairtInfo.EndtDate == null


                                    //ItemType = types,
                                }).ToListAsync();
        }
    }
}
