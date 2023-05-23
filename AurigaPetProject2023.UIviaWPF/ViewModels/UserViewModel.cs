using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using System.ComponentModel;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class UserViewModel : BaseModel
    {
        public UserViewModel()
        {
            _model = UserModel.GetInstance();

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
    }



}
