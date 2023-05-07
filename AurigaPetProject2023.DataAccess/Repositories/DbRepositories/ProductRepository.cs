

using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class ProductRepository: IProductRepository
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
    }
}
