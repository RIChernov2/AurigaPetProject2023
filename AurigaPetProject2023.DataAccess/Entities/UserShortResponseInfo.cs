using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class UserShortResponseInfo: IUserShortResponseInfo
    {
        public UserShortResponseInfo(User user)
        {
            UserID = user.UserID;
            LoginName = user.LoginName;
            Phone = user.Phone;
        }
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string Phone { get; set; }

        public string Print()
        {
            return $"ID=> {UserID}, Login/Phone => {LoginName ??= "-"}/{Phone ??= "-"}";
        }
    }
}
