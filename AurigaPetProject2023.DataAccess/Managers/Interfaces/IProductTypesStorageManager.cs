using AurigaPetProject2023.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Managers.Interfaces
{
    public interface IProductTypesStorageManager
    {
        Task<List<ProductType>> GetAllAsync();
        List<ProductType> GetAll();
    }
}
