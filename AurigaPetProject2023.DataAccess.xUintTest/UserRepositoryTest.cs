//using AurigaPetProject2023.DataAccess.Entities;
//using AurigaPetProject2023.DataAccess.Helpers;
//using AurigaPetProject2023.DataAccess.Repositories;
//using AurigaPetProject2023.DataAccess.Repositories.DbRepositories;
//using AurigaPetProject2023.DataAccess.xUintTest.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;

//namespace AurigaPetProject2023.DataAccess.xUintTest
//{
//    public class UserRepositoryTest
//    {
//        private DbContextOptions<MyContext> _dbContextOptions;
//        public UserRepositoryTest()
//        {
//            string dbName = $"RepairingInfoRepositoryDb_{DateTime.Now.ToFileTimeUtc()}";
//            _dbContextOptions = new DbContextOptionsBuilder<MyContext>()
//                .UseInMemoryDatabase(dbName)
//                .Options;
//        }

//        [Fact]
//        public async Task GetAsync_Success_Test()
//        {
//            var repository = await CreateRepositoryAsync();
//            var loginInfo1 = new UserLoginInfoTest("User1", "111");
//            var loginInfo2 = new UserLoginInfoTest("User2", "222");
//            var loginInfo3 = new UserLoginInfoTest("User3", "000");

//            // Act
//            var entity1 = await repository.GetUserForLoginAsync(loginInfo1);
//            var entity2 = await repository.GetUserForLoginAsync(loginInfo2);
//            var entity3 = await repository.GetUserForLoginAsync(loginInfo3);


//            //Assert.Equal("User1", entity1.LoginName);
//            //Assert.Equal("User2", entity2.LoginName);
//            Assert.Null(entity1);
//            Assert.Null(entity2);
//            Assert.Null(entity3);
//        }
//        private async Task<UserRepository> CreateRepositoryAsync()
//        {
//            MyContextCopyForTest context = new MyContextCopyForTest(_dbContextOptions);
//            await PopulateDataAsync(context);
//            return new UserRepository(context);
//        }
//        private async Task PopulateDataAsync(MyContextCopyForTest context)
//        {
//            int index = 1;

//            while (index <= 3)
//            {
//                var entity = new User()
//                {
//                    LoginName = $"User{index}",
//                    Password = HashHelper.GetHash($"{index}{index}{index}")
//                };
//                var entity2 = new Role()
//                {
//                    UserID = index,
//                    RoleTypeID = index
//                };

//                index++;
//                await context.Users.AddAsync(entity);
//                //await context.Roles.AddAsync(entity2);
//            }

//            await context.SaveChangesAsync();
//        }
//    }
//}


