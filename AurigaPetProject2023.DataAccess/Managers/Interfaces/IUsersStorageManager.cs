using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Managers.Interfaces
{
    public interface IUsersStorageManager
    {
        Task<IUserLoginResponseInfo> GetUserForLoginAsync(IUserLoginInfo info);
        Task<User> GetAsync(int id);
    }
}
