﻿using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class ItemTypeRepository : GenericRepository<ItemType, int>, IItemTypeRepository
    {
        public ItemTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
