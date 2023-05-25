using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UIviaWPF.Entities;
using System;
using System.ComponentModel;
using System.Linq;

namespace AurigaPetProject2023.UIviaWPF.Models
{
    public class UserModel : BaseModel
    {
        private UserModel()
        {
            ItemWithRentInfos = new BindingList<ItemWithRentInfo>();
        }
        private IUserResponseInfo _userInfo;
        private static UserModel _model;
        public static UserModel GetInstance()
        {
            if (_model == null)
            {
                _model = new UserModel();
            }

            return _model;
        }

        public void SetUserInfo(IUserResponseInfo userInfo)
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

        public BindingList<ItemWithRentInfo> ItemWithRentInfos { get; set; }
        public void LoadRentItems()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ItemStorageManager(unitOfWork);
                var list = manager.GetInRent();

                //ProductTypes = new BindingList<ProductType>(list);
                ItemWithRentInfos.Clear();
                foreach (var item in list.Where(x => x.RentInfo.UserID == _userInfo.UserID))
                {
                    ItemWithRentInfos.Add(item);
                }
            }
        }
    }
}
