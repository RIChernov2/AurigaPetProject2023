using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using AurigaPetProject2023.DataAccess.Repositories;
using AurigaPetProject2023.DataAccess.Repositories.DbRepositories;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace AurigaPetProject2023.DataAccess.Managers
{
    public class UnitOfWork : IUnitOfWork
    {
        // не забудь добавить в ResetRepositories
        private IDbContextTransaction _transaction;
        private IUserRepository _usersRepository;
        //private IRoleRepository _roleRepository;
        private IItemTypeRepository _itemTypeRepository;
        private IItemRepository _itemRepository;
        private IDisabledInfoRepository _disabledInfoRepository;
        private IRepairingInfoRepository _repairingInfoRepository;
        private DbContext _context;

        public UnitOfWork()
        {
            _context = new NewContext();
            _transaction = _context.Database.BeginTransaction();
        }

        public IUserRepository UserRepository => _usersRepository ??= new UserRepository(_context);
        //public IRoleRepository RoleRepository => _roleRepository ??= new RoleRepository(_context);
        public IItemTypeRepository ItemTypeRepository => _itemTypeRepository ??= new ItemTypeRepository(_context);
        public IItemRepository ItemRepository => _itemRepository ??= new ItemRepository(_context);
        public IDisabledInfoRepository DisabledInfoRepository => _disabledInfoRepository ??= new DisabledInfoRepository(_context);
        public IRepairingInfoRepository RepairingInfoRepository => _repairingInfoRepository ??= new RepairingInfoRepository(_context);


        public void Commit()
        {
            try
            {
                _context.SaveChanges();
                _transaction.Commit();

            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _context.Database.BeginTransaction();
                ResetRepositories();
            }
        }

        private void ResetRepositories()
        {
            _usersRepository = null;
            //_roleRepository = null;
            _itemTypeRepository = null;
            _itemRepository = null;
            _disabledInfoRepository = null;
            _repairingInfoRepository = null;
        }

        // еще надо почитать про управляемые и не управляемые ресурсы
        #region DISPOSE implementation

        private bool _disposed;
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    ResetRepositories();
                }
                ReleaseUnmanagedResources();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void ReleaseUnmanagedResources()
        {
            _transaction?.Dispose();
            _transaction = null;
            _context?.Dispose();
            _context = null;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}
