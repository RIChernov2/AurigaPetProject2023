using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using System.Collections.Generic;
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
        //{
        //    //User user = await _uow.UserRepository.GetAsync(id);
        //    //IReadOnlyList<int> rolesList= await _uow.RoleRepository.GetRolesByIdAsync(id);
        //    //user.Roles.AddRange(rolesList);
        //    //return user;

        //    var userTask = _uow.UserRepository.GetAsync(id);
        //    var rolesListTask = _uow.RoleRepository.GetRolesByIdAsync(id);




        //    return await userTask.Result.Roles.AddRange(rolesListTask.Result);
        //    return user;
        //}
    }
}
