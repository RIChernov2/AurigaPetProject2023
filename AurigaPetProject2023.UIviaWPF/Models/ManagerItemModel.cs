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
    public class ManagerItemModel : BaseModel, INotifyPropertyChanged
    {
        private ManagerItemModel()
        {

            AvaliableItems = new BindingList<Item>();
            ItemsIsLoaded = false;

            DisabledItems = new BindingList<ItemWithDisableInfo>();
            DisableOperationStatusInfo = new LabelInfo();
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
        public  void LoadItems()
        {
            LoadAvaliableItems();
            LoadDisabledItems();
            ItemsIsLoaded = true;
        }
        public bool ItemsIsLoaded
        {
            get { return _iItemsIsLoaded; }
            set
            {
                _iItemsIsLoaded = value;
                OnPropertyChanged(nameof(ItemsIsLoaded));
            }
        }
        private bool _iItemsIsLoaded;

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
        public BindingList<Item> AvaliableItems { get; private set; }
        private void LoadAvaliableItems()
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
        private void LoadDisabledItems()
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

                //var list = manager.GetDisabled();

                //DisabledItems.Clear();
                //foreach (var item in list)
                //{
                //    DisabledItems.Add(item);
                //}
            }

            if(result ==1)
            {
                DisableReason = "";
                SelectedAvaliableItem = null;
                LoadItems();
                DisableOperationStatusInfo.Text = "Операция успешно завершена";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(DisableOperationStatusInfo, Brushes.Green);
            }
        }

        #endregion
    }
}
