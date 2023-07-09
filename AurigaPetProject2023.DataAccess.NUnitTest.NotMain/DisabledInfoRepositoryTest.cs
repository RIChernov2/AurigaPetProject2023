using NUnit.Framework;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories;
using AurigaPetProject2023.DataAccess.Repositories.DbRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;


namespace AurigaPetProject2023.DataAccess.NUnitTest.NotMain
{
    public class DisabledInfoRepositoryTest
    {
        private DbContextOptions<MyContext> _dbContextOptions;
        private DisabledInfoRepository _repository;

        [SetUp]
        public void Setup()
        {
            string dbName = $"DisabledInfoRepositoryDb_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
            var tast = Task.Run(async () =>
            {
                _repository = await CreateRepositoryAsync();
            });
            tast.Wait();
        }


        [Test]
        public async Task CreateAsync_Success_Test()
        {
            int index = 4;
            // Act
            await _repository.CreateAsync(new DisabledInfo()
            {
                //DisabledInfoID = index,
                ItemID = index,
                Date = DateTime.Now.AddDays(-index),
                Reason = $"Reason {index}"
            });

            // Assert
            var entityList = await _repository.GetAsync();

            Assert.AreEqual(4, entityList.Count);
        }

        // проверяем и этот метод, коли его создали
        [Test]
        public async Task GetAsync_Success_Test()
        {
            // Act
            var entityList = await _repository.GetAsync();

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