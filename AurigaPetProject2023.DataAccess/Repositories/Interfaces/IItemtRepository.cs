﻿using AurigaPetProject2023.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IItemtRepository
    {
        Task<IReadOnlyList<Item>> GetAsync();
        Task<int> CreateAsync(Item entity);
        int GetLastId();
        Task<int> CreateUniqueIdAsync(int itemId);
    }
}
