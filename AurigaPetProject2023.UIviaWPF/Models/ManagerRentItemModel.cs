using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UIviaWPF.Entities;
using System.Collections.Generic;
using System.ComponentModel;

namespace AurigaPetProject2023.UIviaWPF.Models
{
    public class ManagerRentItemModel: BaseModel
    {
        private ManagerRentItemModel()
        {
            Users = new BindingList<IUserResponseInfo>();
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
        public BindingList<IUserResponseInfo> Users { get; set; }
        public IUserResponseInfo SelectedUser 
        { 
            get { return _selectedUser; }
            set 
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        private IUserResponseInfo _selectedUser;

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
    }
}
