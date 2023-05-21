﻿using AurigaPetProject2023.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IDisabledInfoRepository
    {
        Task<int> CreateAsync(DisabledInfo entity);
        //Task<IReadOnlyList<DisabledInfo>> GetAsync();

    }
}
