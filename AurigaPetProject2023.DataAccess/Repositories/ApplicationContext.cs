using Microsoft.EntityFrameworkCore;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Helpers;

namespace AurigaPetProject2023.DataAccess.Repositories
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ProductType> ProductTypes { get; set; } = null;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = DateBaseHelper.GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);

            // настравиваем маппинг bool в байт

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductType>()
                .Property(p => p.IsUnique)
                .HasConversion(
                    v => v ? 1 : 0,
                    v => v == 1);
        }
    }
}
