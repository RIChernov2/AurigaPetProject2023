using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
