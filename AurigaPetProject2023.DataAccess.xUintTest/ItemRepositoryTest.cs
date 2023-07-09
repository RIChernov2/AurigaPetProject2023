using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories;
using AurigaPetProject2023.DataAccess.Repositories.DbRepositories;
using AurigaPetProject2023.DataAccess.xUintTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace AurigaPetProject2023.DataAccess.xUintTest
{
    public class ItemRepositoryTest
    {
        private DbContextOptions<MyContext> _dbContextOptions;

        public ItemRepositoryTest()
        {
            string dbName = $"DisabledInfoRepositoryDb_{DateTime.Now.ToFileTimeUtc()}";
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
            await repository.CreateAsync(new Item()
            {
                ItemTypeID = index,
                Description = $"Description {index}"
            });

            // Assert
            var entityList = await repository.GetAsync();
            Assert.Equal(_itemsCount + 1, entityList.Count);
        }
        [Fact]
        public async Task CreateUniqueIdAsync_Success_Test()
        {
            var repository = await CreateItemRepositoryAsync();

            int index = 3;
            // Act
            await repository.CreateUniqueIdAsync(index + 1);

            // Assert
            var entity = await repository.GetUniqueItemByIdAsync(index);
            Assert.Equal(index, entity.ItemUniqueID);
            Assert.Equal(index + 1, entity.ItemID);
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
            Assert.Equal(2, items.Count);
            Assert.True(result1);
            Assert.True(result2);
        }

        [Fact]
        public async Task GetDisabledAsync_Success_Test()
        {
            var repository = await CreateItemRepositoryAsync();

            // Act
            var items = await repository.GetDisabledAsync();
            bool result1 = items.Select(x => x.ItemData.ItemID).Contains(1);


            // Assert
            Assert.Equal(1, items.Count);
            Assert.True(result1);
        }
        [Fact]
        public async Task GetRepairingAsync_Success_Test()
        {
            var repository = await CreateItemRepositoryAsync();

            // Act
            var items = await repository.GetRepairingAsync();
            bool result1 = items.Select(x => x.ItemData.ItemID).Contains(2);


            // Assert
            Assert.Equal(1, items.Count);
            Assert.True(result1);
        }
        [Fact]
        public async Task GetInRentAsync_Success_Test()
        {
            var repository = await CreateItemRepositoryAsync();

            // Act
            var items = await repository.GetInRentAsync();
            bool result1 = items.Select(x => x.ItemData.ItemID).Contains(3);


            // Assert
            Assert.Equal(1, items.Count);
            Assert.True(result1);
        }


        private async Task<ItemRepository> CreateItemRepositoryAsync()
        {
            MyContextCopyForTest context = new MyContextCopyForTest(_dbContextOptions);
            await PopulateDataAsync(context);
            return new ItemRepository(context);
        }


        private int _itemsCount = 5;

        private async Task PopulateDataAsync(MyContextCopyForTest context)
        {
            int index = 1;

            // Items + ItemTypes
            while (index <= _itemsCount)
            {
                var entity = new Item()
                {
                    ItemTypeID = index,
                    Description = $"Description {index}"
                };

                var entity2 = new ItemType()
                {
                    ItemTypeID = index,
                    Name = $"Name {index}",
                    IsUnique = index == 1 || index == 2
                };


                index++;
                await context.Items.AddAsync(entity);
                await context.ItemTypes.AddAsync(entity2);
            }

            // ItemUniqueInfos
            index = 1;
            while (index <= 2)
            {
                var entity = new ItemUniqueInfo()
                {
                    ItemID = index,
                };

                index++;
                await context.ItemUniqueInfos.AddAsync(entity);
            }

            // DisabledInfos
            var disabledInfo = new DisabledInfo()
            {
                DisabledInfoID = 1,
                ItemID = 1,
                Date = DateTime.Now,
                Reason = "Reason"
            };
            await context.DisabledInfos.AddAsync(disabledInfo);

            // RepairingInfos
            var repairingInfo = new RepairingInfo()
            {
                RepairingInfoID = 1,
                ItemID = 2,
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = null,
                Reason = "Reason",
                ResultDescription = null
            };
            await context.RepairingInfos.AddAsync(repairingInfo);

            // RentInfos
            var rentInfo = new RentInfo()
            {
                RentInfoID = 1,
                UserID = 1,
                ItemID = 3,
                StartDate = DateTime.Now.AddDays(-1),
                ExpireDate = DateTime.Now.AddDays(6),
                EndDate = null,
                Cost = 100,
                IsPaid = true
            };
            await context.RentInfos.AddAsync(rentInfo);

            await context.SaveChangesAsync();
        }
    }
}
