using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerRepairItemViewModel : BaseModel, INotifyPropertyChanged
    {
        public ManagerRepairItemViewModel()
        {
            _model = ManagerRepairItemModel.GetInstance();

            LoadAvaliableItemsCommand = new RelayCommand(_model.LoadAvaliableItems);
            LoadRepairItemsCommand = new RelayCommand(_model.LoadRepairItems);
            RepairItemCommand = new RelayCommand(_model.RepairItem);
        }
        private ManagerRepairItemModel _model;
        public bool AvaliableItemsIsLoaded
        {
            get { return _model.AvaliableItemsIsLoaded; }
            set
            {
                _model.AvaliableItemsIsLoaded = value;
                OnPropertyChanged(nameof(AvaliableItemsIsLoaded));
            }
        }
        public bool RepairingItemsIsLoaded
        {
            get { return _model.RepairingItemsIsLoaded; }
            set
            {
                _model.RepairingItemsIsLoaded = value;
                OnPropertyChanged(nameof(RepairingItemsIsLoaded));
            }
        }

        public string RepairReason
        {
            get { return _model.RepairReason; }
            set
            {
                _model.RepairReason = value;
                OnPropertyChanged(nameof(RepairReason));
            }
        }
        public LabelInfo RepairOperationStatusInfo
        {
            get { return _model.RepairOperationStatusInfo; }
            set
            {
                _model.RepairOperationStatusInfo = value;
                OnPropertyChanged(nameof(RepairOperationStatusInfo));
            }
        }
        public Item SelectedAvaliableItem
        {
            get { return _model.SelectedAvaliableItem; }
            set
            {
                _model.SelectedAvaliableItem = value;
                OnPropertyChanged(nameof(SelectedAvaliableItem));
            }
        }
        public ItemWithRepairingInfoInfo SelectedRepairingItem
        {
            get { return _model.SelectedRepairingItem; }
            set
            {
                _model.SelectedRepairingItem = value;
                OnPropertyChanged(nameof(SelectedRepairingItem));
            }
        }
        public BindingList<Item> AvaliableItems => _model.AvaliableItems;
        public BindingList<ItemWithRepairingInfoInfo> RepairingItems => _model.RepairingItems;


        public ICommand LoadAvaliableItemsCommand { get; }
        public ICommand LoadRepairItemsCommand { get; }
        public ICommand RepairItemCommand { get; }

    }
}
