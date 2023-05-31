using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Helpers;
using AurigaPetProject2023.UIviaWPF.Windows.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AurigaPetProject2023.UIviaWPF.Models
{
    public class ManagerRentItemModel : BaseModel
    {
        private ManagerRentItemModel()
        {
            Users = new BindingList<IUserWithDiscountInfo>();
            RentMounthLengths = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            RentItems = new BindingList<ItemWithRentInfo>();

            RentOutOperationStatusInfo = new LabelInfo();
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
        public BindingList<Item> AvaliableItems => _managerItemModel.AvaliableItems;
        public void LoadAvaliableItems() => _managerItemModel.LoadAvaliableItems();

        public BindingList<IUserWithDiscountInfo> Users { get; set; }
        public IUserWithDiscountInfo SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                SetTotalCost();
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        private IUserWithDiscountInfo _selectedUser;

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
                var list = manager.GetUsersWithDiscountInfo();

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

        public bool IsPaid
        {
            get { return _isPaid; }
            set
            {
                _isPaid = value;
                OnPropertyChanged(nameof(IsPaid));
            }
        }
        public bool _isPaid;

        public LabelInfo RentOutOperationStatusInfo
        {
            get { return _rentOutOperationStatusInfo; }
            set
            {
                _rentOutOperationStatusInfo = value;
                OnPropertyChanged(nameof(RentOutOperationStatusInfo));
            }
        }
        public LabelInfo _rentOutOperationStatusInfo;

        private void SetTotalCost()
        {
            int itemNumber = (int) (SelectedRentLength == null ? 0 : SelectedRentLength);
            int discount = SelectedUser == null ? 0 : SelectedUser.DiscountPercentage;
            TotalCost = Price * itemNumber * (1 - discount/100.0);
        }

        public void ActionOnPriceValidationFailing()
        {
            TotalCost = 0;
        }
        public void RentOutItem()
        {
            if (SelectedAvaliableItem == null)
            {
                RentOutOperationStatusInfo.Text = "Необходимо выбрать оборудование для аренды.";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(RentOutOperationStatusInfo, Brushes.Red);
                return;
            }

            if (SelectedUser == null)
            {
                RentOutOperationStatusInfo.Text = "Необходимо выбрать пользователя, арендующего оборудование.";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(RentOutOperationStatusInfo, Brushes.Red);
                return;
            }

            if (TotalCost == 0)
            {
                RentOutOperationStatusInfo.Text = "Укажите цену и срок аренды.";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(RentOutOperationStatusInfo, Brushes.Red);
                return;
            }


            var answer = MessageBox.Show("Вы уверены, что хотите сдать в аренду данное оборудование:" +
                $"{Environment.NewLine}{Environment.NewLine}" +
                $"ID - {SelectedAvaliableItem.ItemID}{Environment.NewLine}" +
                $"Тип - \"{SelectedAvaliableItem.ItemType.Name}{Environment.NewLine}\"" +
                $"Описание - \"{SelectedAvaliableItem.Description}\"{Environment.NewLine}{Environment.NewLine}" +
                $"Срок аренды - {SelectedRentLength} недели(ль) {Environment.NewLine}" + 
                $"Скидка (если имеется) - {SelectedUser.DiscountPercentage}%{Environment.NewLine}" +
                $"Итоговая цена аренды - {TotalCost}{Environment.NewLine}" +
                $"Оплата за аренду внечена - {(IsPaid ? "Да" : "Нет")}{Environment.NewLine}" + Environment.NewLine +
                $"Данные арендатора: ID = { SelectedUser.UserID}, Login = { SelectedUser.LoginName ??= "none"}, Phone = { SelectedUser.Phone ??= "none"}{ Environment.NewLine}",
                "Подтверждение удаления",
                MessageBoxButton.YesNo);


            if (answer == MessageBoxResult.No) return;



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

        public BindingList<ItemWithRentInfo> RentItems;
        public ItemWithRentInfo SelectedRentItem
        {
            get { return _selectedRentItem; }
            set
            {
                _selectedRentItem = value;
                OnPropertyChanged(nameof(SelectedRentItem));
            }
        }
        private ItemWithRentInfo _selectedRentItem;
        public bool RentItemIsLoaded
        {
            get { return _rentItemIsLOaded; }
            set
            {
                _rentItemIsLOaded = value;
                OnPropertyChanged(nameof(RentItemIsLoaded));
            }
        }
        private bool _rentItemIsLOaded;

        public void LoadRentItems()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ItemStorageManager(unitOfWork);
                var list = manager.GetInRent();

                //ProductTypes = new BindingList<ProductType>(list);
                RentItems.Clear();
                foreach (var item in list)
                {
                    RentItems.Add(item);
                }
                RentItemIsLoaded = true;
            }
        }
    }
}
