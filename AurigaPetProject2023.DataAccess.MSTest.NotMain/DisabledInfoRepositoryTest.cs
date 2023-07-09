using Microsoft.VisualStudio.TestTools.UnitTesting;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories;
using AurigaPetProject2023.DataAccess.Repositories.DbRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.MSTest.NotMain
{
    [TestClass]
    public class DisabledInfoRepositoryTest
    {
        private DbContextOptions<MyContext> _dbContextOptions;

        public DisabledInfoRepositoryTest()
        {
            string dbName = $"DisabledInfoRepositoryDb_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [TestMethod]
        public async Task CreateAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            int index = 4;
            // Act
            await repository.CreateAsync(new DisabledInfo()
            {
                //DisabledInfoID = index,
                ItemID = index,
                Date = DateTime.Now.AddDays(-index),
                Reason = $"Reason {index}"
            });

            // Assert
            var entityList = await repository.GetAsync();

            Assert.AreEqual(4, entityList.Count);
        }

        // проверяем и этот метод, коли его создали
        [TestMethod]
        public async Task GetAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act
            var entityList = await repository.GetAsync();

            // Assert
            Assert.AreEqual(3, entityList.Count);
        }

        private async Task<DisabledInfoRepository> CreateRepositoryAsync()
        {
            MyContextCopyForTest context = new MyContextCopyForTest(_dbContextOptions);
            await PopulateDataAsync(context);
            return new DisabledInfoRepository(context);
        }

        private async Task PopulateDataAsync(MyContextCopyForTest context)
        {
            int index = 1;

            while (index <= 3)
            {
                var entity = new DisabledInfo()
                {
                    //DisabledInfoID = index,
                    ItemID = index,
                    Date = DateTime.Now.AddDays(-index),
                    Reason = $"Reason {index}"
                };

                index++;
                await context.DisabledInfos.AddAsync(entity);
            }

            await context.SaveChangesAsync();
        }
    }
}
