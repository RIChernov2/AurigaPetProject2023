using AurigaPetProject2023.DataAccess.Repositories.Interfaces;


namespace AurigaPetProject2023.DataAccess.xUintTest.Entities
{
    public class UserLoginInfoTest : IUserLoginInfo
    {
        public UserLoginInfoTest(string loginOrPhone, string password)
        {
            LoginOrPhone = loginOrPhone;
            Password = password;
        }

        public string LoginOrPhone { get; set; }
        public string Password { get; set; }

    }
}
