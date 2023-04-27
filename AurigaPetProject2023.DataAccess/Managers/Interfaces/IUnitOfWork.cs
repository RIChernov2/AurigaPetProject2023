using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using System;


namespace AurigaPetProject2023.DataAccess.Managers.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IProductTypeRepository ProductTypeRepository { get; }
        void Commit();
    }
}
