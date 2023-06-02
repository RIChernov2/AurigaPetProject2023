using AurigaPetProject2023.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IUserResponseInfo> GetUserForLoginAsync(IUserLoginInfo info);
        Task<IReadOnlyList<IUserWithDiscountInfo>> GetUsersWithDiscountInfoAsync();
    }
}

