using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerRentItemViewModel : BaseModel
    {
        public ManagerRentItemViewModel()
        {
            _model = ManagerRentItemModel.GetInstance();

            LoadAvaliableItemsCommand = new RelayCommand(_model.LoadAvaliableItems);
            LoadUsersCommand = new RelayCommand(_model.LoadUsers);
            LoadUsersCommand = new RelayCommand(_model.RentItem);

            _model.PropertyChanged += OnMyModelPropertyChanged;
        }

        private static ManagerRentItemModel _model;
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

        public BindingList<IUserShortResponseInfo> Users => _model.Users;
        public IUserShortResponseInfo SelectedUser
        {
            get { return _model.SelectedUser; }
            set
            {
                _model.SelectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public bool UsersIsLoaded
        {
            get { return _model.UsersIsLoaded; }
            set
            {
                _model.UsersIsLoaded = value;
                OnPropertyChanged(nameof(UsersIsLoaded));
            }
        }


        public int[] RentMounthLengths => _model.RentMounthLengths;
        public int SelectedRentLength
        {
            get { return _model.SelectedRentLength; }
            set
            {
                _model.SelectedRentLength = value;
                OnPropertyChanged(nameof(SelectedRentLength));
            }
        }
        public double Price
        {
            get { return _model.Price; }
            set
            {
                _model.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public double TotalCost
        {
            get { return _model.TotalCost; }
            set
            {
                _model.TotalCost = value;
                OnPropertyChanged(nameof(TotalCost));
            }
        }

        public ICommand LoadAvaliableItemsCommand { get; }
        public ICommand LoadUsersCommand { get; }
        public ICommand RentItemCommand { get; }
    }
}
