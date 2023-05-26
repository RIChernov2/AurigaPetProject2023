using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

        //public async Task<User> GetAsync(int id) => await _uow.UserRepository.GetAsync(id);
        public async Task<IUserResponseInfo> GetUserForLoginAsync(IUserLoginInfo info) 
            => await _uow.UserRepository.GetUserForLoginAsync(info);

        public List<IUserShortResponseInfo> GetUsersInfo()
        {
            List<IUserShortResponseInfo> result = new List<IUserShortResponseInfo>();

            Task resultTask = Task.Run(async () =>
            {
                result = (await _uow.UserRepository.GetUsersInfoAsync()).ToList();
            });
            Task.WaitAll(resultTask);

            return result;
        }


    }
}
