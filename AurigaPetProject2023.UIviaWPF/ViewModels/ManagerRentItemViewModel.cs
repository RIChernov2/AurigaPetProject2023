using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using AurigaPetProject2023.UIviaWPF.ValidationRules;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerRentItemViewModel : BaseModel
    {
        public ManagerRentItemViewModel()
        {
            _model = ManagerRentItemModel.GetInstance();

            LoadUsersCommand = new RelayCommand(_model.LoadUsers);
            RentOutItemCommand = new RelayCommand(_model.RentOutItem);
            PriceValidationFailingCommand = new RelayCommand(_model.ActionOnPriceValidationFailing);
            LoadRentItemsCommand = new RelayCommand(_model.LoadRentItems);
            ReturnFromRentCommand = new RelayCommand(_model.ReturnFromRent);

            _model.PropertyChanged += OnMyModelPropertyChanged;
        }

        private ManagerRentItemModel _model;
        public Item SelectedAvaliableItem
        {
            get { return _model.SelectedAvaliableItem; }
            set
            {
                _model.SelectedAvaliableItem = value;
                OnPropertyChanged(nameof(SelectedAvaliableItem));
            }
        }
        public BindingList<Item> AvaliableItems => _model.AvaliableItems;
        public BindingList<IUserWithDiscountInfo> Users => _model.Users;

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
        public int? SelectedRentLength
        {
            get { return _model.SelectedRentLength; }
            set
            {
                _model.SelectedRentLength = value;
                OnPropertyChanged(nameof(SelectedRentLength));
            }
        }
        public ItemWithRentInfo SelectedRentItem
        {
            get { return _model.SelectedRentItem; }
            set
            {
                _model.SelectedRentItem = value;
                OnPropertyChanged(nameof(SelectedRentItem));
            }
        }
        public IUserWithDiscountInfo SelectedUser
        {
            get { return _model.SelectedUser; }
            set
            {
                _model.SelectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        public IUserWithDiscountInfo SelectedUserInFilter
        {
            get { return _model.SelectedUserInFilter; }
            set
            {
                _model.SelectedUserInFilter = value;
                OnPropertyChanged(nameof(SelectedUserInFilter));
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
        public bool IsPaid
        {
            get { return _model.IsPaid; }
            set
            {
                _model.IsPaid = value;
                OnPropertyChanged(nameof(IsPaid));
            }
        }

        public BindingList<ItemWithRentInfo> RentItems => _model.RentItems;
        public bool RentItemIsLoaded
        {
            get { return _model.RentItemIsLoaded; }
            set
            {
                _model.RentItemIsLoaded = value;
                OnPropertyChanged(nameof(RentItemIsLoaded));
            }
        }
        public LabelInfo RentOutOperationStatusInfo
        {
            get { return _model.RentOutOperationStatusInfo; }
            set
            {
                _model.RentOutOperationStatusInfo = value;
                OnPropertyChanged(nameof(RentOutOperationStatusInfo));
            }
        }
        public LabelInfo RetuenFromRentOperationStatusInfo
        {
            get { return _model.RetuenFromRentOperationStatusInfo; }
            set
            {
                _model.RetuenFromRentOperationStatusInfo = value;
                OnPropertyChanged(nameof(RetuenFromRentOperationStatusInfo));
            }
        }
        public ICommand LoadUsersCommand { get; }
        public ICommand RentOutItemCommand { get; }
        public ICommand PriceValidationFailingCommand { get; }
        public ICommand LoadRentItemsCommand { get; }
        public ICommand ReturnFromRentCommand { get; }
    }
}
