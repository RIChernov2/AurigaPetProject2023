using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.UIviaWPF.Entities;
using System.ComponentModel;

namespace AurigaPetProject2023.UIviaWPF.Models
{
    public class ManagerRepairItemModel: BaseModel, INotifyPropertyChanged
    {
        public ManagerRepairItemModel()
        {
            RepairingItems = new BindingList<ItemWithRepairingInfoInfo>();
            //ItemsIsLoaded = false;

            //DisabledItems = new BindingList<ItemWithDisableInfo>();
            //DisableOperationStatusInfo = new Labe
        }
        private static ManagerRepairItemModel _model;
        public static ManagerRepairItemModel GetInstance()
        {
            if (_model == null)
            {
                _model = new ManagerRepairItemModel();
            }

            return _model;
        }

        public void LoadItems()
        {
            LoadRepairItems();
            ItemsIsLoaded = true;
        }
        public bool ItemsIsLoaded
        {
            get { return _itemsIsLoaded; }
            set
            {
                _itemsIsLoaded = value;
                OnPropertyChanged(nameof(ItemsIsLoaded));
            }
        }
        public bool _itemsIsLoaded;



        #region RepairItems
        public BindingList<ItemWithRepairingInfoInfo> RepairingItems { get; private set; }
        public ItemWithRepairingInfoInfo SelectedRepairingItem
        {
            get { return _selectedRepairingItem; }
            set
            {
                _selectedRepairingItem = value;
                OnPropertyChanged(nameof(SelectedRepairingItem));
            }
        }
        private ItemWithRepairingInfoInfo _selectedRepairingItem;

        public void LoadRepairItems()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ItemStorageManager(unitOfWork);
                var list = manager.GetRepairing();

                RepairingItems.Clear();
                foreach (var item in list)
                {
                    RepairingItems.Add(item);
                }
            }
        }

        #endregion
    }
}
