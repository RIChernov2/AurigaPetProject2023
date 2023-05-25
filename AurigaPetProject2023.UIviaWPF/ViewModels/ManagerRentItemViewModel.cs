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

            LoadUsersCommand = new RelayCommand(_model.LoadUsers);

            _model.PropertyChanged += OnMyModelPropertyChanged;
        }

        private static ManagerRentItemModel _model;

        public BindingList<IUserResponseInfo> Users => _model.Users;
        public IUserResponseInfo SelectedUser
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

        public ICommand LoadUsersCommand { get; }
    }
}
