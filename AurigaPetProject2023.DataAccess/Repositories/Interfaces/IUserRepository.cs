using AurigaPetProject2023.DataAccess.Entities;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        Task<IUserLoginResponseInfo> GetUserForLoginAsync(IUserLoginInfo info);
    }
}

