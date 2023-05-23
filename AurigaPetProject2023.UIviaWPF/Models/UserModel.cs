using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UIviaWPF.Entities;
using System;
using System.ComponentModel;

namespace AurigaPetProject2023.UIviaWPF.Models
{
    public class UserModel : BaseModel
    {
        private UserModel()
        {

        }
        private IUserLoginResponseInfo _userInfo;
        private static UserModel _model;
        public static UserModel GetInstance()
        {
            if (_model == null)
            {
                _model = new UserModel();
            }

            return _model;
        }

        public void SetUserInfo(IUserLoginResponseInfo userInfo)
        {
            _userInfo = userInfo;

            string login = userInfo.LoginName ??= "-";
            string phone = userInfo.Phone ??= "-";

            UserInfoHeader = $"Ваш ID - {userInfo.UserID}" + Environment.NewLine +
                            $"Ваши логин / телефон: {login} / {phone}";
        }


        public string UserInfoHeader
        {
            get { return _userInfoHeadern; }
            set
            {
                _userInfoHeadern = value;
                OnPropertyChanged(nameof(UserInfoHeader));
            }
        }
        public string _userInfoHeadern;
    }
}
