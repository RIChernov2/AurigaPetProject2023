using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Managers
{
    public class UsersStorageManager: IUsersStorageManager
    {
        private readonly IUnitOfWork _uow;

        public UsersStorageManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<User> GetAsync(int id) => await _uow.UserRepository.GetAsync(id);
        public async Task<User> GetUserForLoginAsync(IUserLoginInfo info) 
            => await _uow.UserRepository.GetUserForLoginAsync(info);


    }
}
