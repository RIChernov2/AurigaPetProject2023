using AurigaPetProject2023.DataAccess.Entities;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IUserLoginResponseInfo> GetUserForLoginAsync(IUserLoginInfo info);
        //Task<User> GetAsync(int id);
    }
}

