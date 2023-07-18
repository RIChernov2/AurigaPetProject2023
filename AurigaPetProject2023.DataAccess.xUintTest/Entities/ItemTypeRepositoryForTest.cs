using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.DbRepositories;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AurigaPetProject2023.DataAccess.xUintTest.Entities
{
    public class ItemTypeRepositoryForTest : GenericRepository<ItemType, int>, IItemTypeRepository
    {
        public ItemTypeRepositoryForTest(DbContext context) : base(context)
        {
        }
    }
}
