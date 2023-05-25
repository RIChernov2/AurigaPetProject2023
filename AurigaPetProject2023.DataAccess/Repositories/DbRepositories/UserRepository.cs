using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Helpers;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class UserRepository : IUserRepository
    {
        private DbContext _context;
        private DbSet<User> _dbSet;

        public UserRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public virtual async Task<IReadOnlyList<IUserResponseInfo>> GetUsersInfoAsync()
        {
            return await (from user in _dbSet
                          where !_context.Set<BannedInfo>().Any(x => x.UserID == user.UserID)
                          && _context.Set<Role>().Where(x=> x.RoleType == 3).Any(x => x.UserID == user.UserID)
                          select new UserResponseInfo(user)
                          ).ToListAsync();
        }

        // спецом не пойми как написано, хотел потестировать предикат
        public virtual async Task<IUserResponseInfo> GetUserForLoginAsync(IUserLoginInfo info)
        {
            var user = (await GetByPredicateAsync(
                u => (u.LoginName == info.LoginOrPhone || u.Phone == info.LoginOrPhone) &&
                u.Password == HashHelper.GetHash(info.Password) && !_context.Set<BannedInfo>().Any(x=> x.UserID == u.UserID)
                )).FirstOrDefault();

            if (user == null) return null;

            UserResponseInfo userResponseInfo = new UserResponseInfo(user);
            return userResponseInfo;                
        }

        private async Task<IReadOnlyList<User>> GetByPredicateAsync(Expression<Func<User, bool>> predicate)
        {
            var users = await _dbSet.Where(predicate).ToListAsync();
            foreach (var user in users)
            {
                user.Roles = await _context.Set<Role>().Where(r => r.UserID == user.UserID).Select(r => r.RoleType).ToListAsync();
            }
            return users;
        }



    }
}
