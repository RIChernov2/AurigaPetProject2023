using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class DisabledInfoRepository : IDisabledInfoRepository
    {
        private DbContext _context;
        private DbSet<DisabledInfo> _dbSet;

        public DisabledInfoRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<DisabledInfo>();
        }

        public async Task<int> CreateAsync(DisabledInfo entity)
        {
            if(entity.DisabledInfoID != 0) throw new InvalidOperationException();

            await _dbSet.AddAsync(entity);
            return _context.SaveChanges();
        }
    }
}
