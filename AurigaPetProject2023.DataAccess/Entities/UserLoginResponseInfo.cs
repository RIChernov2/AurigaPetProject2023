using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class UserLoginResponseInfo: IUserLoginResponseInfo
    {
        public UserLoginResponseInfo(User user)
        {
            UserID = user.UserID;
            LoginName = user.LoginName;
            Phone = user.Phone;
            Roles = user.Roles;
        }
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string Phone { get; set; }
        public List<int> Roles { get; set; }
    }
}
