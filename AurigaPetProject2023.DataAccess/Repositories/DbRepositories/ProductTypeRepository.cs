using AurigaPetProject2023.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.DbRepositories
{
    public class ProductTypeRepository : GenericRepository<ProductType, int>
    {
        public ProductTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
