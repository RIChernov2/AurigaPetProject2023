using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using System.ComponentModel;


namespace AurigaPetProject2023.UI.Models
{
    public class ManagerModel
    {
        public BindingList<ProductType> ProductTypes { get; private set; }
        public void LoadProductTypes()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ProductTypesStorageManager(unitOfWork);
                var list = manager.GetAll();
                ProductTypes = new BindingList<ProductType>(list);
            }
        }
    }
}
