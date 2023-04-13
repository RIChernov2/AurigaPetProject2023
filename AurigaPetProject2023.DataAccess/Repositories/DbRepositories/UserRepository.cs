﻿using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Tasks;

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

        public virtual async Task<int> CreateAsync(User entity)
        {
            //await _dbSet.AddAsync(entity);
            //return await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }



        public virtual async Task<IReadOnlyList<User>> GetAsync()
        {
            //return await _dbSet.ToListAsync();
            throw new NotImplementedException();

        }


        public virtual async Task<User> GetAsync(int id)
        {
            var user = await _dbSet.FindAsync(id);
            var roles = await _context.Set<Role>().Where(r => r.UserID == id).Select(r=> r.RoleType).ToListAsync();
            user.Roles = roles;
            return user;
        }

        public virtual async Task<IReadOnlyList<User>> GetByPredicateAsync(Expression<Func<User, bool>> predicate)
        {
            //return await _dbSet.Where(predicate).ToListAsync();
            throw new NotImplementedException();
        }


        public virtual async Task<int> UpdateAsync(User entity)
        {
            //_dbSet.Attach(entity); // про это еще стоит почитать, походу тут обновлять не будет
            //_context.Entry(entity).State = EntityState.Modified;
            //return await _context.SaveChangesAsync();

            throw new NotImplementedException();
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            //var entity = await _dbSet.FindAsync(id);
            //if (entity != null)
            //{
            //    _dbSet.Remove(entity);
            //    return await _context.SaveChangesAsync();
            //}
            //else return 0;
            throw new NotImplementedException();
        }
    }
}
