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
    public class GenericRepositoryTest
    {
        private DbContextOptions<MyContext> _dbContextOptions;

        public GenericRepositoryTest()
        {
            string dbName = $"GenericRepositoryDb_{DateTime.Now.ToFileTimeUtc()}";
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
            await repository.CreateAsync(new ItemType()
            {
                Name = $"Name {index}",
                IsUnique = index % 2 == 0
            });

            // Assert
            var entityList = await repository.GetAsync();
            Assert.Equal(4, entityList.Count);
        }

        [Fact]
        public async Task GetAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act
            var entityList = await repository.GetAsync();

            // Assert
            Assert.Equal(3, entityList.Count);
        }

        [Fact]
        public async Task GetByIdAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act
            var entityList = await repository.GetAsync(3);

            // Assert
            Assert.Equal(3, entityList.ItemTypeID);
        }

        [Fact]
        public async Task GetByPredicateAsync1_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act
            var entityList = await repository.GetByPredicateAsync(x=> x.ItemTypeID == 3);

            // Assert
            Assert.Equal(3, entityList.First().ItemTypeID);
        }
        [Fact]
        public async Task GetByPredicateAsync2_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act
            var entityList = await repository.GetByPredicateAsync(x => !x.IsUnique);

            // Assert
            Assert.Equal(2, entityList.Count());
        }

        [Fact]
        public async Task UpdateAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();
            var entity = await repository.GetAsync(3);
            entity.Name = $"NewItem3";
            entity.IsUnique = true;

            //var entity = new ItemType()
            //{
            //    ItemTypeID = 3,
            //    Name = $"NewItem3",
            //    IsUnique = true
            //};

            // Act
            await repository.UpdateAsync(entity);
            entity = await repository.GetAsync(3);

            // Assert
            Assert.Equal("NewItem3", entity.Name);
            Assert.True(entity.IsUnique);
        }

        [Fact]
        public async Task DeleteAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act
            await repository.DeleteAsync(3);

            // Assert
            var entityList = await repository.GetAsync();
            Assert.Equal(2, entityList.Count);
        }



        private async Task<ItemTypeRepositoryTest> CreateRepositoryAsync()
        {
            MyContextCopyForTest context = new MyContextCopyForTest(_dbContextOptions);
            await PopulateDataAsync(context);
            return new ItemTypeRepositoryTest(context);
        }

        private async Task PopulateDataAsync(MyContextCopyForTest context)
        {
            int index = 1;

            while (index <= 3)
            {
                var entity = new ItemType()
                {
                    Name = $"Name {index}",
                    IsUnique = index % 2 == 0
                };

                index++;
                await context.ItemTypes.AddAsync(entity);
            }

            await context.SaveChangesAsync();
        }
    }
}
