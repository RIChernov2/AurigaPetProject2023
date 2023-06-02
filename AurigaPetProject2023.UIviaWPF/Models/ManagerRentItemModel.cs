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
using System.Linq;
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
            UsersWithRent = new BindingList<IUserWithDiscountInfo>();
            RentMounthLengths = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            _rentItems = new BindingList<ItemWithRentInfo>();
            FilteredRentItems = new BindingList<ItemWithRentInfo>();

            RentOutOperationStatusInfo = new LabelInfo();
            RetuenFromRentOperationStatusInfo = new LabelInfo();

            _rentItems.ListChanged += (o, e) => SetUsersInFilter();
            _rentItems.ListChanged += (o, e) => SetFilteredRentItems();
            this.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == "SelectedUserInFilter") SetFilteredRentItems();
            };
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

        public BindingList<Item> AvaliableItems => _managerItemModel.AvaliableItems;

        public BindingList<IUserWithDiscountInfo> Users { get; set; }
        public BindingList<IUserWithDiscountInfo> UsersWithRent { get; set; }
        public int[] RentMounthLengths { get; }
        private BindingList<ItemWithRentInfo> _rentItems;
        public BindingList<ItemWithRentInfo> FilteredRentItems;


        public bool AvaliableItemsIsLoaded
        {
            get { return _managerItemModel.AvaliableItemsIsLoaded; }
            set
            {
                _managerItemModel.AvaliableItemsIsLoaded = value;
                OnPropertyChanged(nameof(AvaliableItemsIsLoaded));
            }
        }
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

        public IUserWithDiscountInfo SelectedUserInFilter
        {
            get { return _selectedUserInFilter; }
            set
            {
                _selectedUserInFilter = value;
                SetTotalCost();
                OnPropertyChanged(nameof(SelectedUserInFilter));
            }
        }
        private IUserWithDiscountInfo _selectedUserInFilter;

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
        public LabelInfo RetuenFromRentOperationStatusInfo
        {
            get { return _retuenFromRentOperationStatusInfo; }
            set
            {
                _retuenFromRentOperationStatusInfo = value;
                OnPropertyChanged(nameof(RetuenFromRentOperationStatusInfo));
            }
        }
        public LabelInfo _retuenFromRentOperationStatusInfo;     

        private void SetTotalCost()
        {
            int itemNumber = (int)(SelectedRentLength == null ? 0 : SelectedRentLength);
            int discount = SelectedUser == null ? 0 : SelectedUser.DiscountPercentage;
            TotalCost = Price * itemNumber * (1 - discount / 100.0);
        }
        public void LoadAvaliableItems() => _managerItemModel.LoadAvaliableItems();
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
        public void LoadRentItems()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ItemStorageManager(unitOfWork);
                var list = manager.GetInRent();

                _rentItems.Clear();
                foreach (var item in list)
                {
                    _rentItems.Add(item);
                }
                RentItemIsLoaded = true;
            }
        }
        private void SetUsersInFilter()
        {
            // запоминаем текущий выбор в фильтре, чтобы потом его восстановить
            int selectedUserID = SelectedUserInFilter == null ? 0 : SelectedUserInFilter.UserID;
            UsersWithRent.Clear();
            //заполняем фильтр по юзеру только теми юзерами, у кого в аренде есть оборудование
            var userIds = _rentItems.Select(x => x.RentInfo.UserID);
            foreach (var item in Users)
            {
                if (userIds.Contains(item.UserID)) UsersWithRent.Add(item);
            }

            // восстанавливаем выбранного юзера в фильтре, если это еещ возможно
            SelectedUserInFilter = UsersWithRent.FirstOrDefault(x => x.UserID == selectedUserID);

        }
        private void SetFilteredRentItems()
        {
            FilteredRentItems.Clear();
            foreach (var item in _rentItems)
            {
                if (SelectedUserInFilter == null || item.RentInfo.UserID == SelectedUserInFilter.UserID) 
                    FilteredRentItems.Add(item);
            }
        }
        public void RemoveFilter()
        {
            SelectedUserInFilter = null;
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



            RentInfo entity = new RentInfo();
            entity.UserID = SelectedUser.UserID;
            entity.ItemID = SelectedAvaliableItem.ItemID;
            entity.StartDate = DateTime.Now;
            entity.ExpireDate = DateTime.Now.AddDays((int)SelectedRentLength * 7);
            entity.Cost = TotalCost;
            entity.IsPaid = IsPaid;

            int result = 0;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new RentInfoStorageManager(unitOfWork);
                result = manager.Create(entity);
            }

            if (result == 1)
            {
                SelectedAvaliableItem = null;
                SelectedUser = null;
                Price = 0;
                IsPaid = false;
                LoadAvaliableItems();
                LoadRentItems();
                RentOutOperationStatusInfo.Text = "Операция успешно завершена";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(RentOutOperationStatusInfo, Brushes.Green);
            }
            else
            {
                RentOutOperationStatusInfo.Text = "Ошибка операции";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(RentOutOperationStatusInfo, Brushes.Red);
            }
        }
        public void ReturnFromRent()
        {
            if (SelectedRentItem == null)
            {
                RetuenFromRentOperationStatusInfo.Text = "Необходимо выбрать оборудование для возврата из аренды.";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(RetuenFromRentOperationStatusInfo, Brushes.Red);
                return;
            }

            var answer = MessageBox.Show("Вы уверены, что хотите завершить аренду данного оборудования:" +
                $"{Environment.NewLine}{Environment.NewLine}" +
                $"ID - {SelectedRentItem.ItemData.ItemID}{Environment.NewLine}" +
                $"Тип - \"{SelectedRentItem.ItemData.ItemType.Name}{Environment.NewLine}\"" +
                $"Описание - \"{SelectedRentItem.ItemData.Description}\"{Environment.NewLine}{Environment.NewLine}",
                "Подтверждение удаления",
                MessageBoxButton.YesNo);


            if (answer == MessageBoxResult.No) return;



            RentInfo entity = SelectedRentItem.RentInfo.GetCopy();
            entity.EndDate = DateTime.Now;
            entity.IsPaid = true;

            int result = 0;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new RentInfoStorageManager(unitOfWork);
                result = manager.Update(entity);

            }

            if (result == 1)
            {
                SelectedRentItem = null;
                LoadAvaliableItems();
                LoadRentItems();

                RetuenFromRentOperationStatusInfo.Text = "Операция успешно завершена";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(RetuenFromRentOperationStatusInfo, Brushes.Green);
            }
            else
            {
                RetuenFromRentOperationStatusInfo.Text = "Ошибка операции";
                new LabelInfoHelper().ChangeStatusColorAndVisibility(RetuenFromRentOperationStatusInfo, Brushes.Red);
            }

        }
    }
}
