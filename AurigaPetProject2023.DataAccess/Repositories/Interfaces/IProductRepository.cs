﻿using AurigaPetProject2023.DataAccess.Entities;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<int> CreateAsync(Product entity);
    }
}