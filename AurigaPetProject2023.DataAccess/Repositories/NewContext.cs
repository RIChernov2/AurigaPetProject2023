using Microsoft.EntityFrameworkCore;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Helpers;

namespace AurigaPetProject2023.DataAccess.Repositories
{
    public class NewContext : DbContext
    {
        public DbSet<ItemType> ItemTypes { get; set; } = null;
        public DbSet<Role> Roles { get; set; } = null;
        public DbSet<User> Users { get; set; } = null;
        public DbSet<Item> Items { get; set; } = null;
        public DbSet<ItemUniqueInfo> ItemUniqueInfos{ get; set; } = null;
        public DbSet<DisabledInfo> DisabledInfos { get; set; } = null;
        public DbSet<RentInfo> RentInfos { get; set; } = null;
        public DbSet<RepairingInfo> RepairingInfos { get; set; } = null;
        public DbSet<DiscountInfo> DiscountInfos { get; set; } = null;
        public DbSet<BannedInfo> BannedInfos { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = DateBaseHelper.GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasNoKey();
            modelBuilder.Entity<User>().Ignore(u => u.Roles);
            modelBuilder.Entity<Item>().Ignore(p => p.ItemType);
            modelBuilder.Entity<Item>().Ignore(p => p.UniqueID);
            modelBuilder.Entity<DiscountInfo>().HasNoKey();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //Func<bool, byte> expression = (boolValue) =>
        //    //{
        //    //    return boolValue ? (byte)1 : (byte)0;
        //    //};

        //    // настравиваем маппинг bool в байт
        //    modelBuilder.Entity<ProductType>()
        //        .Property(p => p.IsUnique)
        //        .HasConversion(x => x ? 1 : 0,
        //            v => v == 1);

        //            //      .HasConversion(
        //            ////v => (byte)(v ? 1 : 0),
        //            //v => (byte)(v ? 1 : 0),
        //            //v => v == 1);
        //}
    }
}
