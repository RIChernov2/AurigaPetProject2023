using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AurigaPetProject2023.DataAccess.xUintTest.ManagerTests
{
    public class DisabledInfoStorageManagerTest
    {
        private IDisabledInfoStorageManager _disabledInfoStorageManager;
        private Mock<IDisabledInfoRepository> _disabledInfoRepository;
        private Mock<IUnitOfWork> _uow;

        public DisabledInfoStorageManagerTest()
        {
            _disabledInfoRepository = new Mock<IDisabledInfoRepository>();

            _uow = new Mock<IUnitOfWork>();
            _uow.Setup(q => q.DisabledInfoRepository).Returns(_disabledInfoRepository.Object);

            _disabledInfoStorageManager = new DisabledInfoStorageManager(_uow.Object);
        }

        [Fact]
        public void Create_Test()
        {
            _disabledInfoRepository.Setup(x => x.CreateAsync(It.IsAny<DisabledInfo>()))
                .ReturnsAsync(1);
            DisabledInfo entity = new DisabledInfo();

            // Act
            var result = _disabledInfoStorageManager.Create(entity);

            // Assert
            Assert.Equal(1, result);
            _disabledInfoRepository.Verify(x => x.CreateAsync(It.IsAny<DisabledInfo>()), Times.Once);
            _uow.Verify(x => x.Commit(), Times.Once);

        }
    }
}
