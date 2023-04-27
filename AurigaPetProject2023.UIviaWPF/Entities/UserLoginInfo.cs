using AurigaPetProject2023.DataAccess.Repositories.Interfaces;


namespace AurigaPetProject2023.UIviaWPF.Entities
{
    public class UserLoginInfo : IUserLoginInfo
    {
        public UserLoginInfo(string loginOrPhone, string password)
        {
            LoginOrPhone = loginOrPhone;
            Password = password;
        }

        public string LoginOrPhone { get; set; }
        public string Password { get; set; }

    }
}
