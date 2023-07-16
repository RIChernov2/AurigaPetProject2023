using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories;
using AurigaPetProject2023.DataAccess.Repositories.DbRepositories;
using AurigaPetProject2023.DataAccess.xUintTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AurigaPetProject2023.DataAccess.xUintTest
{
    public class RentInfoRepositoryTest
    {
        private DbContextOptions<MyContext> _dbContextOptions;
        public RentInfoRepositoryTest()
        {
            string dbName = $"RentInfoRepositoryDb_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public async Task CreateAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            int index = 4;
            // Act
            await repository.CreateAsync(new RentInfo()
            {
                RentInfoID = index,
                UserID = index,
                ItemID = index,
                StartDate = DateTime.Now.AddDays(-index),
                ExpireDate = DateTime.Now.AddDays(index),
                EndDate = null,
                Cost = 100,
                IsPaid = true
            });

            // Assert
            var entityList = await repository.GetAsync();
            Assert.Equal(4, entityList.Count);
        }
        [Fact]
        public async Task UpdateAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();
            var entities = await repository.GetAsync();
            var entity = entities.Where(x => x.ItemID == 3).First();
            entity.Cost = 1000;
            entity.IsPaid = false;

            // Act
            await repository.UpdateAsync(entity);
            entity = (await repository.GetAsync())
                .Where(x => x.ItemID == 3).First();

            // Assert
            Assert.Equal(1000, entity.Cost);
            Assert.False(entity.IsPaid);
        }
        // проверяем и этот метод, коли его создали
        [Fact]
        public async Task GetAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act
            var entityList = await repository.GetAsync();

            // Assert
            Assert.Equal(3, entityList.Count);
        }

        private async Task<RentInfoRepository> CreateRepositoryAsync()
        {
            MyContextCopyForTest context = new MyContextCopyForTest(_dbContextOptions);
            await PopulateDataAsync(context);
            return new RentInfoRepository(context);
        }
        private async Task PopulateDataAsync(MyContextCopyForTest context)
        {
            int index = 1;

            while (index <= 3)
            {
                var entity = new RentInfo()
                {
                    RentInfoID = index,
                    UserID = index,
                    ItemID = index,
                    StartDate = DateTime.Now.AddDays(-index),
                    ExpireDate = DateTime.Now.AddDays(index),
                    EndDate = null,
                    Cost = 100,
                    IsPaid = true
                };

                index++;
                await context.RentInfos.AddAsync(entity);
            }

            await context.SaveChangesAsync();
        }
    }
}
