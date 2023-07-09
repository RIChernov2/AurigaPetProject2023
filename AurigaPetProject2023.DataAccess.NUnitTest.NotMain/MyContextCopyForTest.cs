using AurigaPetProject2023.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AurigaPetProject2023.DataAccess.NUnitTest.NotMain
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
    }
}
