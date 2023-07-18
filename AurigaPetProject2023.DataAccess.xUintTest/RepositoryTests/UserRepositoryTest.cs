using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Helpers;
using AurigaPetProject2023.DataAccess.Repositories;
using AurigaPetProject2023.DataAccess.Repositories.DbRepositories;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.DataAccess.xUintTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AurigaPetProject2023.DataAccess.xUintTest.RepositoryTests
{
    public class UserRepositoryTest
    {
        private DbContextOptions<MyContext> _dbContextOptions;
        public UserRepositoryTest()
        {
            string dbName = $"RepairingInfoRepositoryDb_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }
        [Fact]
        public async Task GetUsersWithDiscountInfoAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act
            List<IUserWithDiscountInfo> users = (await repository.GetUsersWithDiscountInfoAsync()).ToList();
            var ids = users.Select(x => x.UserID);
            bool contaits1 = ids.Contains(1);
            bool contaits2 = ids.Contains(2);
            bool contaits4 = ids.Contains(4);

            Assert.False(contaits1);
            Assert.False(contaits2);
            Assert.False(contaits4);
            Assert.Equal(12, users.Where(x => x.UserID == 3).First().DiscountPercentage);
            Assert.Equal(0, users.Where(x => x.UserID == 5).First().DiscountPercentage);
        }
        [Fact]
        public async Task GetUserForLoginAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();
            var loginInfo1 = new UserLoginInfoTest("User1", "111");
            var loginInfo2 = new UserLoginInfoTest("User2", "222");
            var loginInfo3 = new UserLoginInfoTest("User3", "000");
            var loginInfo4 = new UserLoginInfoTest("User4", "444");

            // Act
            var entity1 = await repository.GetUserForLoginAsync(loginInfo1);
            var entity2 = await repository.GetUserForLoginAsync(loginInfo2);
            var entity3 = await repository.GetUserForLoginAsync(loginInfo3);
            var entity4 = await repository.GetUserForLoginAsync(loginInfo4);

            // Assert
            Assert.Equal("User1", entity1.LoginName);
            Assert.Equal("User2", entity2.LoginName);
            Assert.Null(entity3);
            Assert.Null(entity4);
        }
        private async Task<UserRepository> CreateRepositoryAsync()
        {
            MyContextCopyForTest context = new MyContextCopyForTest(_dbContextOptions);
            await PopulateDataAsync(context);
            return new UserRepository(context);
        }
        private async Task PopulateDataAsync(MyContextCopyForTest context)
        {
            int index = 1;

            while (index <= 5)
            {
                var entity = new User()
                {
                    LoginName = $"User{index}",
                    Password = HashHelper.GetHash($"{index}{index}{index}")
                };
                var entity2 = new Role()
                {
                    UserID = index,
                    RoleTypeID = index < 3 ? index : 3
                };


                index++;
                await context.Users.AddAsync(entity);
                await context.Roles.AddAsync(entity2);
            }

            var entity3 = new BannedInfo()
            {
                BannedInfoID = 1,
                UserID = 4,
                Date = DateTime.Now.AddDays(-5),
                Reason = "Didn't ask me with respect"
            };
            await context.BannedInfos.AddAsync(entity3);

            var entity4 = new DiscountInfo()
            {
                DiscountInfoID = 1,
                UserID = 2,
                DiscountPercentage = 10
            };
            var entity5 = new DiscountInfo()
            {
                DiscountInfoID = 2,
                UserID = 3,
                DiscountPercentage = 12
            };
            var entity6 = new DiscountInfo()
            {
                DiscountInfoID = 3,
                UserID = 4,
                DiscountPercentage = 15
            };
            await context.DiscountInfos.AddAsync(entity4);
            await context.DiscountInfos.AddAsync(entity5);
            await context.DiscountInfos.AddAsync(entity6);

            await context.SaveChangesAsync();
        }
    }
}


