using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class ProductRepository : IProductRepository
    {
        private DbContext _context;
        private DbSet<Product> _dbSet;

        public ProductRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Product>();
        }

        public virtual async Task<int> CreateAsync(Product entity)
        {
            await _dbSet.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<IReadOnlyList<Product>> GetAsync()
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

            return await (from products in _context.Set<Product>()
                          join types in _context.Set<ProductType>()
                          on products.ProductTypeID equals types.ProductTypeID
                          select new Product()
                          {
                              ProductID = products.ProductTypeID,
                              ProductTypeID = products.ProductTypeID,
                              Description = products.Description,
                              ProductType = types,
                          }).ToListAsync();
        }
    }
}
