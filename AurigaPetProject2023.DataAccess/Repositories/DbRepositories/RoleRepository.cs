using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class RoleRepository: IRoleRepository
    {
        private DbContext _context;
        //private DbSet<TEntity> _dbSet;

        public RoleRepository(DbContext context)
        {
            _context = context;
            //_dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IReadOnlyList<int>> GetRolesByIdAsync(int userID)
        {
            return await _context.Set<Role>().Where(r => r.UserID == userID).Select(r => r.RoleType).ToListAsync();
        }
    }
}
