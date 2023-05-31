using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class RentInfoRepository : IRentInfoRepository
    {
        private DbContext _context;
        private DbSet<RentInfo> _dbSet;

        public RentInfoRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<RentInfo>();
        }


        public async Task<int> CreateAsync(RentInfo entity)
        {
            await _dbSet.AddAsync(entity);
            return _context.SaveChanges();
        }

        public async Task<int> UpdateAsync(RentInfo entity)
        {
            _dbSet.Attach(entity); // про это еще стоит почитать, походу тут обновлять не будет
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
