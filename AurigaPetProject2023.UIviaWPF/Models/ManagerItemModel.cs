using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.UIviaWPF.Entities;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AurigaPetProject2023.UIviaWPF.Models
{
    public class ManagerItemModel : BaseModel
    {
        public ManagerItemModel()
        {
            AvaliableItems = new ObservableCollection<Item>();
            AvaliableItemsIsLoaded = false;
        }
        private static ManagerItemModel _model;
        public static ManagerItemModel GetInstance()
        {
            if (_model == null)
            {
                _model = new ManagerItemModel();
            }

            return _model;
        }

        public bool AvaliableItemsIsLoaded
        {
            get { return _itemsIsLoaded; }
            set
            {
                _itemsIsLoaded = value;
                OnPropertyChanged(nameof(AvaliableItemsIsLoaded));
            }
        }
        public bool _itemsIsLoaded;

        public ObservableCollection<Item> AvaliableItems { get; private set; }
        public void LoadAvaliableItems()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ItemStorageManager(unitOfWork);
                var list = manager.GetAvailiable();

                AvaliableItems.Clear();
                foreach (var item in list)
                {
                    AvaliableItems.Add(item);
                }
                AvaliableItemsIsLoaded = true;
            }
        }
    }
}
