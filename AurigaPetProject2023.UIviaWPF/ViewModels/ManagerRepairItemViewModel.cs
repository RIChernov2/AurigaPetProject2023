using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerRepairItemViewModel : BaseModel
    {
        public ManagerRepairItemViewModel()
        {
            _model = ManagerRepairItemModel.GetInstance();

            LoadRepairItemsCommand = new RelayCommand(_model.LoadRepairItems);
            RepairItemCommand = new RelayCommand(_model.RepairItem);
            AbortRepairItemCommand = new RelayCommand(_model.AbortRepairItem);

            _model.PropertyChanged += OnMyModelPropertyChanged;
        }
        private ManagerRepairItemModel _model;
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
        public string RepairResultDescription
        {
            get { return _model.RepairResultDescription; }
            set
            {
                _model.RepairResultDescription = value;
                OnPropertyChanged(nameof(RepairResultDescription));
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

        public LabelInfo AbortRepairOperationStatusInfo
        {
            get { return _model.AbortRepairOperationStatusInfo; }
            set
            {
                _model.AbortRepairOperationStatusInfo = value;
                OnPropertyChanged(nameof(AbortRepairOperationStatusInfo));
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


        public ICommand LoadRepairItemsCommand { get; }
        public ICommand RepairItemCommand { get; }
        public ICommand AbortRepairItemCommand { get; }

    }
}
