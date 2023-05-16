using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using System;


namespace AurigaPetProject2023.DataAccess.Managers.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IItemTypeRepository ItemTypeRepository { get; }
        IItemtRepository ItemRepository { get; }
        IDisabledInfoRepository DisabledInfoRepository { get; }
        void Commit();
    }
}
