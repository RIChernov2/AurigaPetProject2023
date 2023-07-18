using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;


namespace AurigaPetProject2023.DataAccess.xUintTest.ManagerTests
{
    public class UsersStorageManagerTest
    {
        private IUsersStorageManager _usersStorageManager;
        private Mock<IUserRepository> _userRepository;
        private Mock<IUnitOfWork> _uow;

        public UsersStorageManagerTest()
        {
            _userRepository = new Mock<IUserRepository>();

            _uow = new Mock<IUnitOfWork>();
            _uow.Setup(q => q.UserRepository).Returns(_userRepository.Object);

            _usersStorageManager = new UsersStorageManager(_uow.Object);
        }

        [Fact]
        public void GetUserForLogin_Test()
        {
            var user1 = new User();
            var user2 = new User();
            var correctResult = new UserResponseInfo(user1);
            var incorrectResult = new UserResponseInfo(user2);

            _userRepository.Setup(x => x.GetUserForLoginAsync(It.IsAny<IUserLoginInfo>()))
                .ReturnsAsync(correctResult);


            // Act
            var result = _usersStorageManager.GetUserForLogin(null);

            // Assert
            Assert.Equal(correctResult, result);
            Assert.NotEqual(incorrectResult, result);
            _userRepository.Verify(x => x.GetUserForLoginAsync(It.IsAny<IUserLoginInfo>()), Times.Once);
        }
        [Fact]
        public void GetUsersWithDiscountInfo_Test()
        {
            var user1 = new User();
            var user2 = new User();
            var correctResult 
                = new List<IUserWithDiscountInfo> { new UserWithDiscountInfo(user1, new DiscountInfo()) };
            var incorrectResult 
                = new List<IUserWithDiscountInfo> { new UserWithDiscountInfo(user2, new DiscountInfo()) };

            _userRepository.Setup(x => x.GetUsersWithDiscountInfoAsync())
                .ReturnsAsync(correctResult);


            // Act
            var result = _usersStorageManager.GetUsersWithDiscountInfo();

            // Assert
            Assert.Equal(correctResult, result);
            Assert.NotEqual(incorrectResult, result);
            _userRepository.Verify(x => x.GetUsersWithDiscountInfoAsync(), Times.Once);
        }
    }
}
