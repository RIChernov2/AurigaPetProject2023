using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Entities;
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
        public bool RepairingItemsIsLoaded
        {
            get { return _itemsIsLoaded; }
            set
            {
                _itemsIsLoaded = value;
                OnPropertyChanged(nameof(RepairingItemsIsLoaded));
            }
        }
        public bool _itemsIsLoaded;

        #region AvaliableItems
        public Item SelectedAvaliableItem
        {
            get { return _selectedAvaliableItem; }
            set
            {
                _selectedAvaliableItem = value;
                OnPropertyChanged(nameof(SelectedAvaliableItem));
            }
        }
        private Item _selectedAvaliableItem;
        private ManagerItemModel _managerItemModel => ManagerItemModel.GetInstance();
        public BindingList<Item> AvaliableItems => _managerItemModel.AvaliableItems;
        public void LoadAvaliableItems() => _managerItemModel.LoadAvaliableItems();
        public bool AvaliableItemsIsLoaded
        {
            get { return _managerItemModel.AvaliableItemsIsLoaded; }
            set
            {
                _managerItemModel.AvaliableItemsIsLoaded = value;
                OnPropertyChanged(nameof(AvaliableItemsIsLoaded));
            }
        }

        #endregion

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
                RepairingItemsIsLoaded = true;
            }
        }
        public void RepairItem()
        {

        }

        #endregion
    }
}
