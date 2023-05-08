using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Xml;

namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class ProductRepository : IProductRepository
    {
        private DbContext _context;
        private DbSet<Item> _dbSet;

        public ProductRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Item>();
        }

        public virtual async Task<int> CreateAsync(Item entity)
        {
            await _dbSet.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<IReadOnlyList<Item>> GetAsync()
        {
            //var query = from products in _context.Set<Product>()
            //            join types in _context.Set<ProductType>()
            //            on products.ProductTypeID equals types.ProductTypeID

            ////return await (from products in _context.Set<Product>()
            ////              join types in _context.Set<ProductType>()
            ////              on products.ProductType_ID equals types.ProductType_ID

            //            //public virtual async Task<IReadOnlyList<TEntity>> GetAsync()
            //            //{
            //            //    return await _dbSet.ToListAsync();
            //            //}

            //return await _dbSet.ToListAsync();

            return await (from products in _context.Set<Item>()
                          join types in _context.Set<ItemType>()
                          on products.ItemTypeID equals types.ItemTypeID
                          //join uniqueIds in _context.Set<UniqueId>()
                          select new Item()
                          {
                              ItemID = products.ItemTypeID,
                              ItemTypeID = products.ItemTypeID,
                              Description = products.Description,
                              ItemType = types,
                          }).ToListAsync();
        }
    }
}
