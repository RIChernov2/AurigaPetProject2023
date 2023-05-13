using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerDisableViewModel : BaseModel
    {
        public ManagerDisableViewModel()
        {
            _model = ManagerItemModel.GetInstance();

            LoadAvailableCommand = new RelayCommand(_model.LoadAvaliableItems);
            LoadDisabledCommand = new RelayCommand(_model.LoadDisabledItems);

            _model.PropertyChanged += OnMyModelPropertyChanged;
        }

        private ManagerItemModel _model;
        public bool AvaliableItemsIsLoaded
        {
            get { return _model.AvaliableItemsIsLoaded; }
            set
            {
                _model.AvaliableItemsIsLoaded = value;
                OnPropertyChanged(nameof(AvaliableItemsIsLoaded));
            }
        }
        public BindingList<Item> AvaliableItems => _model.AvaliableItems;


        public bool DisabledItemsIsLoaded
        {
            get { return _model.DisabledItemsIsLoaded; }
            set
            {
                _model.DisabledItemsIsLoaded = value;
                OnPropertyChanged(nameof(DisabledItemsIsLoaded));
            }
        }
        public BindingList<Item> DisabledItems => _model.DisabledItems;

        ICommand LoadAvailableCommand { get; }
        ICommand LoadDisabledCommand { get; }



        //public BindingList<ItemType> ItemTypes => _model.ItemTypes;
    }
}
