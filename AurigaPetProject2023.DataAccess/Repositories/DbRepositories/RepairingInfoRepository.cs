using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class RepairingInfoRepository : IRepairingInfoRepository
    {
        private DbContext _context;
        private DbSet<RepairingInfo> _dbSet;

        public RepairingInfoRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<RepairingInfo>();
        }


        public async Task<int> CreateAsync(RepairingInfo entity)
        {
            if (entity.RepairingInfoID != 0) throw new InvalidOperationException();

            await _dbSet.AddAsync(entity);
            return _context.SaveChanges();
        }

        public async Task<int> UpdateAsync(RepairingInfo entity)
        {
            _dbSet.Attach(entity); // про это еще стоит почитать, походу тут обновлять не будет
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        // создаем метод для проведения тестов
        public virtual async Task<IReadOnlyList<RepairingInfo>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
