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
    public class ItemTypesStorageManagerTest
    {
        private IItemTypesStorageManager _itemTypesStorageManager;
        private Mock<IItemTypeRepository> _itemTypeRepository;
        private Mock<IUnitOfWork> _uow;

        public ItemTypesStorageManagerTest()
        {
            _itemTypeRepository = new Mock<IItemTypeRepository>();

            _uow = new Mock<IUnitOfWork>();
            _uow.Setup(q => q.ItemTypeRepository).Returns(_itemTypeRepository.Object);

            _itemTypesStorageManager = new ItemTypesStorageManager(_uow.Object);
        }

        [Fact]
        public void GetAllAsync_Test()
        {
            var correctResult = new List<ItemType>() { new ItemType() };
            var incorrectResult = new List<ItemType>() { new ItemType() };

            _itemTypeRepository.Setup(x => x.GetAsync())
                .ReturnsAsync(correctResult);
            ItemType entity = new ItemType();

            // Act
            List<ItemType> result = null;
            Task.Run(async () =>
            {
                result = await _itemTypesStorageManager.GetAllAsync();
            }).Wait();

            //result = await _itemTypesStorageManager.GetAllAsync();

            // Assert
            Assert.Equal(correctResult, result);
            Assert.NotEqual(incorrectResult, result);
            _itemTypeRepository.Verify(x => x.GetAsync(), Times.Once);
        }

        [Fact]
        public void GetAll_Test()
        {
            var correctResult = new List<ItemType>() { new ItemType() };
            var incorrectResult = new List<ItemType>() { new ItemType() };

            _itemTypeRepository.Setup(x => x.GetAsync())
                .ReturnsAsync(correctResult);
            ItemType entity = new ItemType();

            // Act
            var result = _itemTypesStorageManager.GetAll();

            // Assert
            Assert.Equal(correctResult, result);
            Assert.NotEqual(incorrectResult, result);
            _itemTypeRepository.Verify(x => x.GetAsync(), Times.Once);
        }
        [Fact]
        public void Create_Test()
        {
            _itemTypeRepository.Setup(x => x.CreateAsync(It.IsAny<ItemType>()))
                .ReturnsAsync(1);
            ItemType entity = new ItemType();

            // Act
            var result = _itemTypesStorageManager.Create(entity);

            // Assert
            Assert.Equal(1, result);
            _itemTypeRepository.Verify(x => x.CreateAsync(It.IsAny<ItemType>()), Times.Once);
            _uow.Verify(x => x.Commit(), Times.Once);

        }
        [Fact]
        public void Update_Test()
        {
            _itemTypeRepository.Setup(x => x.UpdateAsync(It.IsAny<ItemType>()))
                .ReturnsAsync(1);
            ItemType entity = new ItemType();

            // Act
            var result = _itemTypesStorageManager.Update(entity);

            // Assert
            Assert.Equal(1, result);
            _itemTypeRepository.Verify(x => x.UpdateAsync(It.IsAny<ItemType>()), Times.Once);
            _uow.Verify(x => x.Commit(), Times.Once);

        }
        [Fact]
        public void Delete_Test()
        {
            _itemTypeRepository.Setup(x => x.DeleteAsync(It.IsAny<int>()))
                .ReturnsAsync(1);

            // Act
            var result = _itemTypesStorageManager.Delete(123);

            // Assert
            Assert.Equal(1, result);
            _itemTypeRepository.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Once);
            _uow.Verify(x => x.Commit(), Times.Once);

        }
    }
}
