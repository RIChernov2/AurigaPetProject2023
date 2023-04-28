using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using AurigaPetProject2023.DataAccess.Repositories;
using AurigaPetProject2023.DataAccess.Repositories.DbRepositories;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace AurigaPetProject2023.DataAccess.Managers
{
    public class UnitOfWork: IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private IUserRepository _usersRepository;
        private IRoleRepository _roleRepository;
        private IProductTypeRepository _productTypeRepository;
        private DbContext _context;

        public UnitOfWork()
        {
            _context = new NewContext();
            _transaction = _context.Database.BeginTransaction();
        }

        public IUserRepository UserRepository => _usersRepository ??= new UserRepository(_context);
        public IRoleRepository RoleRepository => _roleRepository ??= new RoleRepository(_context);
        public IProductTypeRepository ProductTypeRepository => _productTypeRepository ??= new ProductTypeRepository(_context);


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
            _roleRepository = null;
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
