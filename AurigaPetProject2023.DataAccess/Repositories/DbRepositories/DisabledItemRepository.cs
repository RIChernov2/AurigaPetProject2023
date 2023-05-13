using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class DisabledItemRepository : IDisabledItemRepository
    {
        private DbContext _context;
        private DbSet<DisabledInfo> _set;

        public DisabledItemRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<DisabledInfo>();
        }

        public async Task<int> CreateAsync(DisabledInfo entity)
        {
            await _set.AddAsync(entity);
            return _context.SaveChanges();
        }
    }
}
