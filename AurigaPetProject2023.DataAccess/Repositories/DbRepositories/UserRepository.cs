using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Helpers;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public virtual async Task<IUserLoginResponseInfo> GetUserForLoginAsync(IUserLoginInfo info)
        {
            var user = (await GetByPredicateAsync(
                u => (u.LoginName == info.LoginOrPhone || u.Phone == info.LoginOrPhone) &&
                u.Password == HashHelper.GetHash(info.Password)
                )).FirstOrDefault();

            if (user == null) return null;

            UserLoginResponseInfo userResponseInfo = new UserLoginResponseInfo(user);
            return userResponseInfo;                
        }



        //public virtual async Task<User> GetAsync(int id)
        //{
        //    var user = await _dbSet.FindAsync(id);
        //    user.Roles  = await _context.Set<Role>().Where(r => r.UserID == id).Select(r => r.RoleType).ToListAsync();
        //    return user;
        //}

        public virtual async Task<IReadOnlyList<User>> GetByPredicateAsync(Expression<Func<User, bool>> predicate)
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
