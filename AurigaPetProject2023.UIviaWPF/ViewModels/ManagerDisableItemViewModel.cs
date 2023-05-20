using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerDisableItemViewModel : BaseModel
    {
        public ManagerDisableItemViewModel()
        {
            _model = ManagerDisableItemModel.GetInstance();

            LoadAvaliableItemsCommand = new RelayCommand(_model.LoadAvaliableItems);
            LoadDisableItemsCommand = new RelayCommand(_model.LoadDisabledItems);
            DisableItemCommand = new RelayCommand(_model.DisableItem);

            _model.PropertyChanged += OnMyModelPropertyChanged;
        }

        private ManagerDisableItemModel _model;
        public bool AvaliableItemsIsLoaded
        {
            get { return _model.AvaliableItemsIsLoaded; }
            set
            {
                _model.AvaliableItemsIsLoaded = value;
                OnPropertyChanged(nameof(AvaliableItemsIsLoaded));
            }
        }
        public bool DisabledItemsIsLoaded
        {
            get { return _model.DisabledItemsIsLoaded; }
            set
            {
                _model.DisabledItemsIsLoaded = value;
                OnPropertyChanged(nameof(DisabledItemsIsLoaded));
            }
        }


        public string DisableReason
        {
            get { return _model.DisableReason; }
            set
            {
                _model.DisableReason = value;
                OnPropertyChanged(nameof(DisableReason));
            }
        }

        public LabelInfo DisableOperationStatusInfo
        {
            get { return _model.DisableOperationStatusInfo; }
            set
            {
                _model.DisableOperationStatusInfo = value;
                OnPropertyChanged(nameof(DisableOperationStatusInfo));
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
        public ItemWithDisableInfo SelectedDisabledItem
        {
            get { return _model.SelectedDisabledItem; }
            set
            {
                _model.SelectedDisabledItem = value;
                OnPropertyChanged(nameof(SelectedDisabledItem));
            }
        }
        public BindingList<Item> AvaliableItems => _model.AvaliableItems;
        public BindingList<ItemWithDisableInfo> DisabledItems => _model.DisabledItems;

        public ICommand LoadAvaliableItemsCommand { get; }
        public ICommand LoadDisableItemsCommand { get; }
        public ICommand DisableItemCommand { get; }




        //public BindingList<ItemType> ItemTypes => _model.ItemTypes;
    }
}
