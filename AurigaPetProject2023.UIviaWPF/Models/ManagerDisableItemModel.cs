using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Helpers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace AurigaPetProject2023.UIviaWPF.Models
{
    public class ManagerDisableItemModel : BaseModel
    {
        private ManagerDisableItemModel()
        {
            DisabledItemsIsLoaded = false;

            DisabledItems = new BindingList<ItemWithDisableInfo>();
            DisableOperationStatusInfo = new LabelInfo();
        }

        private static ManagerDisableItemModel _model;
        public static ManagerDisableItemModel GetInstance()
        {
            if (_model == null)
            {
                _model = new ManagerDisableItemModel();
            }

            return _model;
        }
        public bool DisabledItemsIsLoaded
        {
            get { return _itemsIsLoaded; }
            set
            {
                _itemsIsLoaded = value;
                OnPropertyChanged(nameof(DisabledItemsIsLoaded));
            }
        }
        private bool _itemsIsLoaded;

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
        public ObservableCollection<Item> AvaliableItems => _managerItemModel.AvaliableItems;
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

        #region DisabledItems
        //public BindingList<Item> DisabledItems { get; private set; }
        public BindingList<ItemWithDisableInfo> DisabledItems { get; private set; }
        public ItemWithDisableInfo SelectedDisabledItem
        {
            get { return _selectedDisabledItem; }
            set
            {
                _selectedDisabledItem = value;
                OnPropertyChanged(nameof(SelectedDisabledItem));
            }
        }
        private ItemWithDisableInfo _selectedDisabledItem;
        public void LoadDisabledItems()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ItemStorageManager(unitOfWork);
                var list = manager.GetDisabled();

                DisabledItems.Clear();
                foreach (var item in list)
                {
                    DisabledItems.Add(item);
                }
                DisabledItemsIsLoaded = true;
            }
        }

        public string DisableReason
        {
            get { return _disableReason; }
            set
            {
                _disableReason = value;
                OnPropertyChanged(nameof(DisableReason));
            }
        }
        public string _disableReason;

        public LabelInfo DisableOperationStatusInfo
        {
            get { return _disableOperationStatusInfo; }
            set
            {
                _disableOperationStatusInfo = value;
                OnPropertyChanged(nameof(DisableOperationStatusInfo));
            }
        }
        public LabelInfo _disableOperationStatusInfo;

        public void DisableItem()
        {
            if (SelectedAvaliableItem == null)
            {
                DisableOperationStatusInfo.Text = "Необходимо выбрать оборудование для списания.";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(DisableOperationStatusInfo, Brushes.Red);
                return;
            }
            if (string.IsNullOrEmpty(DisableReason))
            {
                DisableOperationStatusInfo.Text = "Необходимо указать причину списания.";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(DisableOperationStatusInfo, Brushes.Red);
                return;
            }


            var answer = MessageBox.Show("Вы уверены, что хотите списать данное оборудование:" +
                $"{Environment.NewLine}{Environment.NewLine}"+
                $"ID - {SelectedAvaliableItem.ItemID}{Environment.NewLine}"+
                $"Тип - \"{SelectedAvaliableItem.ItemType.Name}{Environment.NewLine}\"" +
                $"Описание - \"{SelectedAvaliableItem.Description}\"{Environment.NewLine}{Environment.NewLine}" +
                $"Причина списания - \"{DisableReason}\"{Environment.NewLine}",
                "Подтверждение удаления",
                MessageBoxButton.YesNo);


             if (answer == MessageBoxResult.No) return;



            DisabledInfo  entity = new DisabledInfo();
            entity.ItemID = SelectedAvaliableItem.ItemID;
            entity.Date = DateTime.Now;
            entity.Reason = DisableReason;
            int result = 0;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new DisabledInfoStorageManager(unitOfWork);
                result = manager.Create(entity);
            }

            if(result ==1)
            {
                DisableReason = "";
                SelectedAvaliableItem = null;
                LoadAvaliableItems();
                LoadDisabledItems();
                DisableOperationStatusInfo.Text = "Операция успешно завершена";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(DisableOperationStatusInfo, Brushes.Green);
            }
            else
            {
                DisableOperationStatusInfo.Text = "Ошибка операции";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(DisableOperationStatusInfo, Brushes.Red);
            }
        }

        #endregion
    }
}
