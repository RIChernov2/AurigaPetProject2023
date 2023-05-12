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
                              ItemID = items.ItemTypeID,
                              ItemTypeID = items.ItemTypeID,
                              Description = items.Description,
                              ItemType = types,
                              UniqueID =  !types.IsUnique ? null : uniqueNumber.ItemUniqueID
                              //ItemType = types,
                          }).ToListAsync();
        }
    }
}
