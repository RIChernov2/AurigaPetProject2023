using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Helpers;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
        public virtual async Task<IReadOnlyList<IUserWithDiscountInfo>> GetUsersWithDiscountInfoAsync()
        {
            #region
            //return await (from user in _dbSet
            //              join discountInfo in _context.Set<DiscountInfo>() on user.UserID equals discountInfo.UserID into discountInfoGroup
            //              from discount in discountInfoGroup.DefaultIfEmpty()

            //              where !_context.Set<BannedInfo>().Any(x => x.UserID == user.UserID)
            //              && _context.Set<Role>().Where(x => x.RoleType == 3).Any(x => x.UserID == user.UserID)
            //              select new UserWithDiscountInfo (user, discount)
            //              ).ToListAsync();
            #endregion

            // переписываем, чтобы потренировать другой способ записаи LINQ
            var result = (await _context.Set<User>().Where(u =>
                        !_context.Set<BannedInfo>().Any(x => x.UserID == u.UserID) &&
                        _context.Set<Role>().Where(x => x.RoleTypeID == 3).Any(x => x.UserID == u.UserID)

                        ).ToListAsync())// перемещаем со стороны БД на сторону клиента
                .GroupJoin(_context.Set<DiscountInfo>(),
                                    user => user.UserID,
                                    discount => discount.UserID,
                                    (user, discountInfoGroup) => new { User = user, Discount = discountInfoGroup.DefaultIfEmpty() })

                //.Select(x => new UserWithDiscountInfo(x.User, x.Discount.FirstOrDefault()))
                .SelectMany(
                        x => x.Discount,
                        (user, discount) => new UserWithDiscountInfo(user.User, discount)
                    )
                .ToList();
            return result;
        }

        public virtual async Task<IUserResponseInfo> GetUserForLoginAsync(IUserLoginInfo info)
        {
           
            var result =  (await _context.Set<User>().Where(u =>
                   (u.LoginName == info.LoginOrPhone || u.Phone == info.LoginOrPhone) &&
                   u.Password == HashHelper.GetHash(info.Password) && !_context.Set<BannedInfo>().Any(x => x.UserID == u.UserID)
               ).Join(_context.Set<Role>(),
                        user => user.UserID,
                        role => role.UserID,
                        (user, role) => new { User = user, Role = role }
                )
               .ToListAsync()) // перемещаем со стороны БД на сторону клиента
               .GroupBy(
                    x => x.User,
                    x => x.Role.RoleTypeID,
                    (user, roles) => new { User = user, Roles = roles.ToList() }
                ).FirstOrDefault();

            if (result == null) return null;
            User user = result.User;
            user.Roles = result.Roles;

            UserResponseInfo userResponseInfo = new UserResponseInfo(user);
            return userResponseInfo;
        }
    }
}










//public virtual async Task<IReadOnlyList<IUserWithDiscountInfo>> GetUsersWithDiscountInfoAsync()
//{
//    return await (from user in _dbSet
//                  join discountInfo in _context.Set<DiscountInfo>() on user.UserID equals discountInfo.UserID into discountInfoGroup
//                  from discount in discountInfoGroup.DefaultIfEmpty()

//                  where !_context.Set<BannedInfo>().Any(x => x.UserID == user.UserID)
//                  && _context.Set<Role>().Where(x => x.RoleType == 3).Any(x => x.UserID == user.UserID)
//                  select new UserWithDiscountInfo(user, discount)
//                  ).ToListAsync();
//}

//// спецом не пойми как написано, хотел потестировать предикат
//public virtual async Task<IUserResponseInfo> GetUserForLoginAsync(IUserLoginInfo info)
//{
//    var user = (await GetByPredicateAsync(
//        u => (u.LoginName == info.LoginOrPhone || u.Phone == info.LoginOrPhone) &&
//        u.Password == HashHelper.GetHash(info.Password) && !_context.Set<BannedInfo>().Any(x => x.UserID == u.UserID)
//        )).FirstOrDefault();

//    if (user == null) return null;

//    UserResponseInfo userResponseInfo = new UserResponseInfo(user);
//    return userResponseInfo;
//}
//private async Task<IReadOnlyList<User>> GetByPredicateAsync(Expression<Func<User, bool>> predicate)
//{
//    var users = await _dbSet.Where(predicate).ToListAsync();
//    foreach (var user in users)
//    {
//        user.Roles = await _context.Set<Role>().Where(r => r.UserID == user.UserID).Select(r => r.RoleType).ToListAsync();
//    }
//    return users;
//}

