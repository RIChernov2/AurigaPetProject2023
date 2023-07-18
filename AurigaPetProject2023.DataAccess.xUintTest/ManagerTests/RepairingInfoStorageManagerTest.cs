using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AurigaPetProject2023.DataAccess.xUintTest.ManagerTests
{
    public class RepairingInfoStorageManagerTest
    {
        private IRepairingInfoStorageManager _RepairingInfoStorageManager;
        private Mock<IRepairingInfoRepository> _RepairingInfoRepository;
        private Mock<IUnitOfWork> _uow;

        public RepairingInfoStorageManagerTest()
        {
            _RepairingInfoRepository = new Mock<IRepairingInfoRepository>();

            _uow = new Mock<IUnitOfWork>();
            _uow.Setup(q => q.RepairingInfoRepository).Returns(_RepairingInfoRepository.Object);

            _RepairingInfoStorageManager = new RepairingInfoStorageManager(_uow.Object);
        }

        [Fact]
        public void Create_Test()
        {
            _RepairingInfoRepository.Setup(x => x.CreateAsync(It.IsAny<RepairingInfo>()))
                .ReturnsAsync(1);
            RepairingInfo entity = new RepairingInfo();

            // Act
            var result = _RepairingInfoStorageManager.Create(entity);

            // Assert
            Assert.Equal(1, result);
            _RepairingInfoRepository.Verify(x => x.CreateAsync(It.IsAny<RepairingInfo>()), Times.Once);
            _uow.Verify(x => x.Commit(), Times.Once);

        }
        [Fact]
        public void Update_Test()
        {
            _RepairingInfoRepository.Setup(x => x.UpdateAsync(It.IsAny<RepairingInfo>()))
                .ReturnsAsync(1);
            RepairingInfo entity = new RepairingInfo();

            // Act
            var result = _RepairingInfoStorageManager.Update(entity);

            // Assert
            Assert.Equal(1, result);
            _RepairingInfoRepository.Verify(x => x.UpdateAsync(It.IsAny<RepairingInfo>()), Times.Once);
            _uow.Verify(x => x.Commit(), Times.Once);

        }
    }
}
