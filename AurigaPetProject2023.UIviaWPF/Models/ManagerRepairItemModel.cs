using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Helpers;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace AurigaPetProject2023.UIviaWPF.Models
{
    public class ManagerRepairItemModel: BaseModel, INotifyPropertyChanged
    {
        public ManagerRepairItemModel()
        {

            RepairingItems = new BindingList<ItemWithRepairingInfoInfo>();
            //ItemsIsLoaded = false;

            //DisabledItems = new BindingList<ItemWithDisableInfo>();
            RepairOperationStatusInfo = new LabelInfo();
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
        public string RepairReason
        {
            get { return _repairReason; }
            set
            {
                _repairReason = value;
                OnPropertyChanged(nameof(RepairReason));
            }
        }
        public string _repairReason;

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

        public LabelInfo RepairOperationStatusInfo
        {
            get { return _repairOperationStatusInfo; }
            set
            {
                _repairOperationStatusInfo = value;
                OnPropertyChanged(nameof(RepairOperationStatusInfo));
            }
        }
        public LabelInfo _repairOperationStatusInfo;
        public void RepairItem()
        {

            if (SelectedAvaliableItem == null)
            {
                RepairOperationStatusInfo.Text = "Необходимо выбрать оборудование для ремонта.";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(RepairOperationStatusInfo, Brushes.Red);
                return;
            }
            if (string.IsNullOrEmpty(RepairReason))
            {
                RepairOperationStatusInfo.Text = "Необходимо указать причину ремонта.";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(RepairOperationStatusInfo, Brushes.Red);
                return;
            }

            var answer = MessageBox.Show("Вы уверены, что хотите списать данное оборудование:" +
                $"{Environment.NewLine}{Environment.NewLine}" +
                $"ID - {SelectedAvaliableItem.ItemID}{Environment.NewLine}" +
                $"Тип - \"{SelectedAvaliableItem.ItemType.Name}{Environment.NewLine}\"" +
                $"Описание - \"{SelectedAvaliableItem.Description}\"{Environment.NewLine}{Environment.NewLine}" +
                $"Причина немонта - \"{RepairReason}\"{Environment.NewLine}",
                "Подтверждение удаления",
                MessageBoxButton.YesNo);


            if (answer == MessageBoxResult.No) return;



            RepairingInfo entity = new RepairingInfo();
            entity.ItemID = SelectedAvaliableItem.ItemID;
            entity.Reason = RepairReason;
            entity.StartDate = DateTime.Now;

            int result = 0;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new RepairingInfoStorageManager(unitOfWork);
                result = manager.Create(entity);

            }

            if (result == 1)
            {
                RepairReason = "";
                SelectedAvaliableItem = null;
                LoadAvaliableItems();
                LoadRepairItems();
                RepairOperationStatusInfo.Text = "Операция успешно завершена";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(RepairOperationStatusInfo, Brushes.Green);
            }
        }

        #endregion
    }
}
