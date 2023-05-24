using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class UserViewModel : BaseModel
    {
        public UserViewModel()
        {
            _model = UserModel.GetInstance();

            LoadRentItemsCommand = new RelayCommand(_model.LoadRentItems);

            _model.PropertyChanged += OnMyModelPropertyChanged;
        }
        private UserModel _model;
        public void SetUserInfo(IUserLoginResponseInfo userInfo) => _model.SetUserInfo(userInfo);
        public string UserInfoHeader
        {
            get { return _model.UserInfoHeader; }
            set
            {
                _model.UserInfoHeader = value;
                OnPropertyChanged(nameof(UserInfoHeader));
            }
        }
        public BindingList<ItemWithRentInfo> ItemWithRentInfos => _model.ItemWithRentInfos;
        public ICommand LoadRentItemsCommand { get; }
    }



}
