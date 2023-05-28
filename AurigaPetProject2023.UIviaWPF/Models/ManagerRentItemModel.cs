using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UIviaWPF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace AurigaPetProject2023.UIviaWPF.Models
{
    public class ManagerRentItemModel: BaseModel
    {
        private ManagerRentItemModel()
        {
            Users = new BindingList<IUserShortResponseInfo>();
            RentMounthLengths = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            //ItemTypesIsLoaded = false;
            //NewItemTypeStatusInfo = new LabelInfo();
        }

        private static ManagerRentItemModel _model;
        public static ManagerRentItemModel GetInstance()
        {
            if (_model == null)
            {
                _model = new ManagerRentItemModel();
            }

            return _model;
        }
        private ManagerItemModel _managerItemModel => ManagerItemModel.GetInstance();
        public bool AvaliableItemsIsLoaded
        {
            get { return _managerItemModel.AvaliableItemsIsLoaded; }
            set
            {
                _managerItemModel.AvaliableItemsIsLoaded = value;
                OnPropertyChanged(nameof(AvaliableItemsIsLoaded));
            }
        }
        public BindingList<Item> AvaliableItems => _managerItemModel.AvaliableItems;
        public void LoadAvaliableItems() => _managerItemModel.LoadAvaliableItems();

        public BindingList<IUserShortResponseInfo> Users { get; set; }
        public IUserShortResponseInfo SelectedUser 
        { 
            get { return _selectedUser; }
            set 
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        private IUserShortResponseInfo _selectedUser;

        public bool UsersIsLoaded
        {
            get { return _usersIsLoaded; }
            set
            {
                _usersIsLoaded = value;
                OnPropertyChanged(nameof(UsersIsLoaded));
            }
        }
        private bool _usersIsLoaded;

        public void LoadUsers()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new UsersStorageManager(unitOfWork);
                var list = manager.GetUsersInfo();

                //ProductTypes = new BindingList<ProductType>(list);
                Users.Clear();
                foreach (var item in list)
                {
                    Users.Add(item);
                }
                UsersIsLoaded = true;
            }
        }

        public int[] RentMounthLengths { get; }
        public int? SelectedRentLength 
        {
            get { return _selectedRentLength; }
            set
            {
                _selectedRentLength = value;
                SetTotalCost();
                OnPropertyChanged(nameof(SelectedRentLength));
            }
        }
        private int? _selectedRentLength;

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                SetTotalCost();
                OnPropertyChanged(nameof(Price));
            }
        }
        private double _price;
        public double TotalCost
        {
            get { return _totalcost; }
            set
            {
                _totalcost = value;
                OnPropertyChanged(nameof(TotalCost));
            }
        }
        private double _totalcost;

        private void SetTotalCost() => TotalCost = Price * (SelectedRentLength ??= 0);

        public void ActionOnPriceValidationFailing()
        {
            TotalCost = 0;
        }
        public void RentOutItem()
        {

            //var answer = MessageBox.Show("Вы уверены, что хотите сдать в аренду данное оборудование:" +
            //    $"{Environment.NewLine}{Environment.NewLine}" +
            //    $"ID - {SelectedAvaliableItem.ItemID}{Environment.NewLine}" +
            //    $"Тип - \"{SelectedAvaliableItem.ItemType.Name}{Environment.NewLine}\"" +
            //    $"Описание - \"{SelectedAvaliableItem.Description}\"{Environment.NewLine}{Environment.NewLine}" +
            //    $"Причина списания - \"{DisableReason}\"{Environment.NewLine}",
            //    "Подтверждение удаления",
            //    MessageBoxButton.YesNo);


            //if (answer == MessageBoxResult.No) return;



            //using (UnitOfWork unitOfWork = new UnitOfWork())
            //{
            //    var manager = new UsersStorageManager(unitOfWork);
            //    var list = manager.GetUsersInfo();

            //    //ProductTypes = new BindingList<ProductType>(list);
            //    Users.Clear();
            //    foreach (var item in list)
            //    {
            //        Users.Add(item);
            //    }
            //    UsersIsLoaded = true;
            //}
        }
    }
}
