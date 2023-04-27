using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IUserLoginResponseInfo
    {
        int UserID { get; set; }
        List<int> Roles { get; set; }
    }
}
