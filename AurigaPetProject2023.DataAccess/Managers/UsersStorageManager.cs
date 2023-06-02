﻿using AurigaPetProject2023.DataAccess.Entities;
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

        public async Task<IUserResponseInfo> GetUserForLoginAsync(IUserLoginInfo info) 
            => await _uow.UserRepository.GetUserForLoginAsync(info);

        public List<IUserWithDiscountInfo> GetUsersWithDiscountInfo()
        {
            List<IUserWithDiscountInfo> result = new List<IUserWithDiscountInfo>();

            Task resultTask = Task.Run(async () =>
            {
                result = (await _uow.UserRepository.GetUsersWithDiscountInfoAsync()).ToList();
            });
            Task.WaitAll(resultTask);

            return result;
        }


    }
}
