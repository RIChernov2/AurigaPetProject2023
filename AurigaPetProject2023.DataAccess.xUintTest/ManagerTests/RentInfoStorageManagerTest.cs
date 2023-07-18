using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AurigaPetProject2023.DataAccess.xUintTest.ManagerTests
{
    public class RentInfoStorageManagerTest
    {
        private IRentInfoStorageManager _rentInfoStorageManager;
        private Mock<IRentInfoRepository> _rentInfoRepository;
        private Mock<IUnitOfWork> _uow;

        public RentInfoStorageManagerTest()
        {
            _rentInfoRepository = new Mock<IRentInfoRepository>();

            _uow = new Mock<IUnitOfWork>();
            _uow.Setup(q => q.RentInfoRepository).Returns(_rentInfoRepository.Object);

            _rentInfoStorageManager = new RentInfoStorageManager(_uow.Object);
        }

        [Fact]
        public void Create_Test()
        {
            _rentInfoRepository.Setup(x => x.CreateAsync(It.IsAny<RentInfo>()))
                .ReturnsAsync(1);
            RentInfo entity = new RentInfo();

            // Act
            var result = _rentInfoStorageManager.Create(entity);

            // Assert
            Assert.Equal(1, result);
            _rentInfoRepository.Verify(x => x.CreateAsync(It.IsAny<RentInfo>()), Times.Once);
            _uow.Verify(x => x.Commit(), Times.Once);

        }
        [Fact]
        public void Update_Test()
        {
            _rentInfoRepository.Setup(x => x.UpdateAsync(It.IsAny<RentInfo>()))
                .ReturnsAsync(1);
            RentInfo entity = new RentInfo();

            // Act
            var result = _rentInfoStorageManager.Update(entity);

            // Assert
            Assert.Equal(1, result);
            _rentInfoRepository.Verify(x => x.UpdateAsync(It.IsAny<RentInfo>()), Times.Once);
            _uow.Verify(x => x.Commit(), Times.Once);

        }
    }
}
