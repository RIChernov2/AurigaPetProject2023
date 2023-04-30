using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class UserLoginResponseInfo: IUserLoginResponseInfo
    {
        public UserLoginResponseInfo(User user)
        {
            UserID = user.UserID;
            Roles = user.Roles;
        }
        public int UserID { get; set; }
        public List<int> Roles { get; set; }
    }
}
