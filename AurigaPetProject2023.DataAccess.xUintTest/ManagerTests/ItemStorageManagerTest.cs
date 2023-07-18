using AurigaPetProject2023.DataAccess.Dto;
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
    public class ItemStorageManagerTest
    {
        private IItemStorageManager _itemStorageManager;
        private Mock<IItemRepository> _itemRepository;
        private Mock<IItemTypeRepository> _itemTypeRepository;
        private Mock<IUnitOfWork> _uow;

        public ItemStorageManagerTest()
        {
            _itemRepository = new Mock<IItemRepository>();
            _itemTypeRepository = new Mock<IItemTypeRepository>();


            _uow = new Mock<IUnitOfWork>();
            _uow.Setup(q => q.ItemRepository).Returns(_itemRepository.Object);
            _uow.Setup(q => q.ItemTypeRepository).Returns(_itemTypeRepository.Object);

            _itemStorageManager = new ItemStorageManager(_uow.Object);
        }

        [Fact]
        public void Create_Unique_Test()
        {
            _itemRepository.Setup(x => x.CreateAsync(It.IsAny<Item>()))
                .ReturnsAsync(1);

            ItemType itemType = new ItemType() { IsUnique = true };
            _itemTypeRepository.Setup(x => x.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(itemType);
            _itemRepository.Setup(x => x.CreateUniqueIdAsync(It.IsAny<int>()))
                .ReturnsAsync(1);



            Item entity = new Item() { ItemTypeID = 123 };

            // Act
            var result = _itemStorageManager.Create(entity);

            // Assert
            Assert.NotEqual(1, result);
            Assert.Equal(2, result);

            _itemRepository.Verify(x => x.CreateAsync(It.IsAny<Item>()), Times.Once);
            _itemTypeRepository.Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once);
            _itemRepository.Verify(x => x.GetLastId(), Times.Once);
            _itemRepository.Verify(x => x.CreateUniqueIdAsync(It.IsAny<int>()), Times.Once);
            _uow.Verify(x => x.Commit(), Times.Once);

        }
        [Fact]
        public void Create_NotUnique_Test()
        {
            _itemRepository.Setup(x => x.CreateAsync(It.IsAny<Item>()))
                .ReturnsAsync(1);

            ItemType itemType = new ItemType() { IsUnique = false };
            _itemTypeRepository.Setup(x => x.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(itemType);

            Item entity = new Item();

            // Act
            var result = _itemStorageManager.Create(entity);

            // Assert
            Assert.Equal(1, result);
            Assert.NotEqual(2, result);

            _itemRepository.Verify(x => x.CreateAsync(It.IsAny<Item>()), Times.Once);
            _itemTypeRepository.Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once);
            _itemRepository.Verify(x => x.GetLastId(), Times.Never);
            _itemRepository.Verify(x => x.CreateUniqueIdAsync(It.IsAny<int>()), Times.Never);
            _uow.Verify(x => x.Commit(), Times.Once);

        }
        [Fact]
        public void GetDisabled_Test()
        {
            var correctResult = new List<ItemWithDisableInfo>() { new ItemWithDisableInfo() };
            var incorrectResult = new List<ItemWithDisableInfo>() { new ItemWithDisableInfo() };

            _itemRepository.Setup(x => x.GetDisabledAsync())
                .ReturnsAsync(correctResult);

            // Act
            var  result = _itemStorageManager.GetDisabled();


            // Assert
            Assert.Equal(correctResult, result);
            Assert.NotEqual(incorrectResult, result);
            _itemRepository.Verify(x => x.GetDisabledAsync(), Times.Once);
        }

        [Fact]
        public void GetRepairing_Test()
        {
            var correctResult = new List<ItemWithRepairingInfoInfo>() { new ItemWithRepairingInfoInfo() };
            var incorrectResult = new List<ItemWithRepairingInfoInfo>() { new ItemWithRepairingInfoInfo() };

            _itemRepository.Setup(x => x.GetRepairingAsync())
                .ReturnsAsync(correctResult);

            // Act
            var result = _itemStorageManager.GetRepairing();


            // Assert
            Assert.Equal(correctResult, result);
            Assert.NotEqual(incorrectResult, result);
            _itemRepository.Verify(x => x.GetRepairingAsync(), Times.Once);
        }
        [Fact]
        public void GetAvailiable_Test()
        {
            var correctResult = new List<Item>() { new Item() };
            var incorrectResult = new List<Item>() { new Item() };

            _itemRepository.Setup(x => x.GetAvailiableAsync())
                .ReturnsAsync(correctResult);

            // Act
            var result = _itemStorageManager.GetAvailiable();


            // Assert
            Assert.Equal(correctResult, result);
            Assert.NotEqual(incorrectResult, result);
            _itemRepository.Verify(x => x.GetAvailiableAsync(), Times.Once);
        }
        [Fact]
        public void GetInRent_Test()
        {
            var correctResult = new List<ItemWithRentInfo>() { new ItemWithRentInfo() };
            var incorrectResult = new List<ItemWithRentInfo>() { new ItemWithRentInfo() };

            _itemRepository.Setup(x => x.GetInRentAsync())
                .ReturnsAsync(correctResult);

            // Act
            var result = _itemStorageManager.GetInRent();


            // Assert
            Assert.Equal(correctResult, result);
            Assert.NotEqual(incorrectResult, result);
            _itemRepository.Verify(x => x.GetInRentAsync(), Times.Once);
        }
    }
}
