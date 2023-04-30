using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class GenericRepository<TEntity, TArg> : IGenericRepository<TEntity, TArg> where TEntity: class
    {
        private DbContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }



        public virtual async Task<IReadOnlyList<TEntity>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }





        public virtual async Task<TEntity> GetAsync(TArg id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async  Task<IReadOnlyList<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }


        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity); // про это еще стоит почитать, походу тут обновлять не будет
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(TArg id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return await _context.SaveChangesAsync();
            }
            else return 0;
        }

        
    }
}
