using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AurigaPetProject2023.DataAccess.xUintTest.Entities
{
    public class MyContextCopyForTest : MyContext
    {
        public MyContextCopyForTest(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
        // чтобы не подключался к ловальной SQL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
