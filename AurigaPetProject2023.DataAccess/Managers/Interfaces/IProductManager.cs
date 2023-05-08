using AurigaPetProject2023.DataAccess.Entities;
using System.Collections.Generic;


namespace AurigaPetProject2023.DataAccess.Managers.Interfaces
{
    public interface IProductManager
    {
        List<Product> GetAll();
    }
}
