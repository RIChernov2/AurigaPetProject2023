using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories;
using AurigaPetProject2023.DataAccess.Repositories.DbRepositories;
using AurigaPetProject2023.DataAccess.xUintTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace AurigaPetProject2023.DataAccess.xUintTest.RepositoryTests
{
    public class ItemRepositoryTest
    {
        private DbContextOptions<MyContext> _dbContextOptions;

        public ItemRepositoryTest()
        {
            string dbName = $"ItemRepositoryDb_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public async Task CreateAsync_Success_Test()
        {
            var repository = await CreateItemRepositoryAsync();

            int index = _itemsCount + 1;
            // Act
            var result = await repository.CreateAsync(new Item()
            {
                ItemTypeID = index,
                Description = $"Description {index}"
            });
            var entityList = await repository.GetAsync();

            // Assert
            Assert.Equal(1, result);
            Assert.Equal(_itemsCount + 1, entityList.Count);
        }
        [Fact]
        public async Task CreateAsync_UnSuccess_Test()
        {
            var repository = await CreateItemRepositoryAsync();
            var result = 0;

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                result = await repository.CreateAsync(new Item()
                {
                    ItemID = 1,
                    ItemTypeID = 0,
                    Description = $"Description {0}"
                });
            });
            Assert.Equal(0, result);
            var entityList = await repository.GetAsync();
            Assert.Equal(_itemsCount, entityList.Count);

        }
        [Fact]
        public async Task CreateUniqueIdAsync_Success_Test()
        {
            var repository = await CreateItemRepositoryAsync();

            int index1 = _uniqueItemsCount + 1;
            int index2 = _itemsCount + 1;
            // Act
            int  result = await repository.CreateUniqueIdAsync(index2);
            ItemUniqueInfo entity = await repository.GetUniqueItemByIdAsync(index1);

            // Assert
            Assert.Equal(1, result);
            Assert.Equal(index1, entity.ItemUniqueID);
            Assert.Equal(index2, entity.ItemID);
        }
        [Fact]
        public async Task GetLastIdAsync1_Success_Test()
        {
            var repository = await CreateItemRepositoryAsync();

            // Act
            int index = repository.GetLastId();

            // Assert
            Assert.Equal(_itemsCount, index);
        }
        [Fact]
        public async Task GetLastIdAsync2_Success_Test()
        {
            var repository = await CreateItemRepositoryAsync();
            int index = _itemsCount + 1;

            // Act
            await repository.CreateAsync(new Item()
            {
                ItemTypeID = index,
                Description = $"Description {index}"
            });
            int resulIndex = repository.GetLastId();

            // Assert
            Assert.Equal(index, resulIndex);

        }
        [Fact]
        public async Task GetAvailiableAsync_Success_Test()
        {
            var repository = await CreateItemRepositoryAsync();

            // Act
            var items = await repository.GetAvailiableAsync();
            bool result1 = items.Select(x => x.ItemID).Contains(4);
            bool result2 = items.Select(x => x.ItemID).Contains(4);

            // Assert
            Assert.Equal(_avaliableItemsCount, items.Count);
            //Assert.True(result1);
            //Assert.True(result2);
        }
        [Fact]
        public async Task GetDisabledAsync_Success_Test()
        {
            var repository = await CreateItemRepositoryAsync();

            // Act
            var items = await repository.GetDisabledAsync();

            // Assert
            Assert.Equal(_countOfEachUnAvaliable, items.Count);
        }
        [Fact]
        public async Task GetRepairingAsync_Success_Test()
        {
            var repository = await CreateItemRepositoryAsync();

            // Act
            var items = await repository.GetRepairingAsync();

            // Assert
            Assert.Equal(_countOfEachUnAvaliable, items.Count);
        }
        [Fact]
        public async Task GetInRentAsync_Success_Test()
        {
            var repository = await CreateItemRepositoryAsync();

            // Act
            var items = await repository.GetInRentAsync();

            // Assert
            Assert.Equal(_countOfEachUnAvaliable, items.Count);
        }

        private async Task<ItemRepository> CreateItemRepositoryAsync()
        {
            MyContextCopyForTest context = new MyContextCopyForTest(_dbContextOptions);
            await PopulateDataAsync(context);
            return new ItemRepository(context);
        }

        private int _itemsCount = 13;
        private int _uniqueItemsCount = 5;
        private int _countOfEachUnAvaliable = 2; // 2 disabled; 2 in repair; 2 in rent;
        private int _avaliableItemsCount = 7; // 13 - 2 x (disabled, repairing, Rented)
        private async Task PopulateDataAsync(MyContextCopyForTest context)
        {
            int index = 1;

            // Items + ItemTypes + ItemUniqueInfos
            while (index <= _itemsCount)
            {
                var entity = new Item()
                {
                    ItemTypeID = index,
                    Description = $"Description {index}"
                };
                await context.Items.AddAsync(entity);

                var entity2 = new ItemType()
                {
                    ItemTypeID = index,
                    Name = $"Name {index}",
                    IsUnique = index <= _uniqueItemsCount
                };
                await context.ItemTypes.AddAsync(entity2);

                if(index <= _uniqueItemsCount)
                {
                    var entity3 = new ItemUniqueInfo()
                    {
                        ItemID = index,
                    };
                    await context.ItemUniqueInfos.AddAsync(entity3);
                }

                index++;
            }


            // DisabledInfos
            var disabledInfo1 = new DisabledInfo()
            {
                DisabledInfoID = 1,
                ItemID = 1,
                Date = DateTime.Now,
                Reason = "Reason"
            };
            var disabledInfo2 = new DisabledInfo()
            {
                DisabledInfoID = 2,
                ItemID = 2,
                Date = DateTime.Now,
                Reason = "Reason"
            };
            await context.DisabledInfos.AddAsync(disabledInfo1);
            await context.DisabledInfos.AddAsync(disabledInfo2);

            // RepairingInfos - two are in repair, on is not (repair finished)
            var repairingInfo1 = new RepairingInfo()
            {
                RepairingInfoID = 1,
                ItemID = 3,
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = null,
                Reason = "Reason",
                ResultDescription = null
            };
            var repairingInfo2 = new RepairingInfo()
            {
                RepairingInfoID = 2,
                ItemID = 4,
                StartDate = DateTime.Now.AddDays(-2),
                EndDate = DateTime.Now,
                Reason = "Reason",
                ResultDescription = "Repaired"
            };
            var repairingInfo3 = new RepairingInfo()
            {
                RepairingInfoID = 3,
                ItemID = 5,
                StartDate = DateTime.Now.AddDays(-3),
                EndDate = null,
                Reason = "Reason",
                ResultDescription = null
            };
            await context.RepairingInfos.AddAsync(repairingInfo1);
            await context.RepairingInfos.AddAsync(repairingInfo2);
            await context.RepairingInfos.AddAsync(repairingInfo3);

            // RentInfos - two are in rent, on is not (rent finished)
            var rentInfo1 = new RentInfo()
            {
                RentInfoID = 1,
                UserID = 1,
                ItemID = 6,
                StartDate = DateTime.Now.AddDays(-1),
                ExpireDate = DateTime.Now.AddDays(6),
                EndDate = null,
                Cost = 101,
                IsPaid = true
            };
            var rentInfo2 = new RentInfo()
            {
                RentInfoID = 2,
                UserID = 2,
                ItemID = 7,
                StartDate = DateTime.Now.AddDays(-2),
                ExpireDate = DateTime.Now.AddDays(5),
                EndDate = DateTime.Now.AddDays(-1),
                Cost = 102,
                IsPaid = true
            };
            var rentInfo3 = new RentInfo()
            {
                RentInfoID = 3,
                UserID = 3,
                ItemID = 8,
                StartDate = DateTime.Now.AddDays(-3),
                ExpireDate = DateTime.Now.AddDays(4),
                EndDate = null,
                Cost = 103,
                IsPaid = true
            };
            await context.RentInfos.AddAsync(rentInfo1);
            await context.RentInfos.AddAsync(rentInfo2);
            await context.RentInfos.AddAsync(rentInfo3);

            await context.SaveChangesAsync();
        }
    }
}
