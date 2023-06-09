﻿using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using System;


namespace AurigaPetProject2023.DataAccess.Managers.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IItemTypeRepository ItemTypeRepository { get; }
        IItemRepository ItemRepository { get; }
        IDisabledInfoRepository DisabledInfoRepository { get; }
        IRepairingInfoRepository RepairingInfoRepository { get; }
        IRentInfoRepository RentInfoRepository { get; }
        void Commit();
    }
}
