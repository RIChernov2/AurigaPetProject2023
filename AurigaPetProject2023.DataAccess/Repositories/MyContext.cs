using Microsoft.EntityFrameworkCore;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Helpers;

namespace AurigaPetProject2023.DataAccess.Repositories
{
    public class MyContext : DbContext
    {
        public MyContext() : base() { }
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<BannedInfo> BannedInfos { get; set; } = null;
        public DbSet<ItemType> ItemTypes { get; set; } = null;
        public DbSet<Role> Roles { get; set; } = null;
        public DbSet<User> Users { get; set; } = null;
        public DbSet<Item> Items { get; set; } = null;
        public DbSet<ItemUniqueInfo> ItemUniqueInfos{ get; set; } = null;
        public DbSet<DisabledInfo> DisabledInfos { get; set; } = null;
        public DbSet<RentInfo> RentInfos { get; set; } = null;
        public DbSet<RepairingInfo> RepairingInfos { get; set; } = null;
        public DbSet<DiscountInfo> DiscountInfos { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = DateBaseHelper.GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetBannedInfoSettings(modelBuilder);
            SetDisabledInfoSettings(modelBuilder);
            SetDiscountInfoSettings(modelBuilder);
            SetItemSettings(modelBuilder);

            modelBuilder.Entity<ItemType>().Property(x => x.ItemTypeID).HasColumnName("ItemType_ID");
            modelBuilder.Entity<ItemType>().Property(x => x.IsUnique).HasColumnName("Is_Unique");

            SetItemUniqueInfoSettings(modelBuilder);
            SetRentInfoSettings(modelBuilder);
            SetRepairingInfoSettings(modelBuilder);
            SetRoleSettings(modelBuilder);

            modelBuilder.Entity<RoleType>().Property(x => x.RoleTypeID).HasColumnName("RoleType_ID");

            modelBuilder.Entity<User>().Property(x => x.UserID).HasColumnName("User_ID");
            modelBuilder.Entity<User>().Property(x => x.LoginName).HasColumnName("Login_Name");
            modelBuilder.Entity<User>().Ignore(u => u.Roles);

            //base.OnModelCreating(modelBuilder);
        }
        private void SetBannedInfoSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BannedInfo>().HasKey(x => x.BannedInfoID);
            modelBuilder.Entity<BannedInfo>().Property(x => x.BannedInfoID).HasColumnName("BannedInfo_ID");
            modelBuilder.Entity<BannedInfo>().Property(x => x.UserID).HasColumnName("User_ID");
        }
        private void SetDisabledInfoSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisabledInfo>().HasKey(x => x.DisabledInfoID);
            modelBuilder.Entity<DisabledInfo>().Property(x => x.DisabledInfoID).HasColumnName("DisabledInfo_ID");
            modelBuilder.Entity<DisabledInfo>().Property(x => x.ItemID).HasColumnName("Item_ID");
        }
        private void SetDiscountInfoSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscountInfo>().HasKey(x => x.DiscountInfoID);
            modelBuilder.Entity<DiscountInfo>().Property(x => x.DiscountInfoID).HasColumnName("DiscountInfo_ID");
            modelBuilder.Entity<DiscountInfo>().Property(x => x.UserID).HasColumnName("User_ID");
        }
        private void SetItemSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().Property(x => x.ItemID).HasColumnName("Item_ID");
            modelBuilder.Entity<Item>().Property(x => x.ItemTypeID).HasColumnName("ItemType_ID");
            modelBuilder.Entity<Item>().Ignore(p => p.ItemType);
            modelBuilder.Entity<Item>().Ignore(p => p.UniqueID);
        }
        private void SetItemUniqueInfoSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemUniqueInfo>().HasKey(x => x.ItemUniqueID);
            modelBuilder.Entity<ItemUniqueInfo>().Property(x => x.ItemUniqueID).HasColumnName("ItemUnique_ID");
            modelBuilder.Entity<ItemUniqueInfo>().Property(x => x.ItemID).HasColumnName("Item_ID");
        }
        private void SetRentInfoSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentInfo>().HasKey(x => x.RentInfoID);
            modelBuilder.Entity<RentInfo>().Property(x => x.RentInfoID).HasColumnName("RentInfo_ID");
            modelBuilder.Entity<RentInfo>().Property(x => x.UserID).HasColumnName("User_ID");
            modelBuilder.Entity<RentInfo>().Property(x => x.ItemID).HasColumnName("Item_ID");
            modelBuilder.Entity<RentInfo>().Property(x => x.StartDate).HasColumnName("Start_Date");
            modelBuilder.Entity<RentInfo>().Property(x => x.ExpireDate).HasColumnName("Expire_Date");
            modelBuilder.Entity<RentInfo>().Property(x => x.EndDate).HasColumnName("End_Date");
        }
        private void SetRepairingInfoSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RepairingInfo>().HasKey(x => x.RepairingInfoID);
            modelBuilder.Entity<RepairingInfo>().Property(x => x.RepairingInfoID).HasColumnName("RepairingInfo_ID");
            modelBuilder.Entity<RepairingInfo>().Property(x => x.ItemID).HasColumnName("Item_ID");
            modelBuilder.Entity<RepairingInfo>().Property(x => x.StartDate).HasColumnName("Start_Date");
            modelBuilder.Entity<RepairingInfo>().Property(x => x.EndDate).HasColumnName("End_Date");
            modelBuilder.Entity<RepairingInfo>().Property(x => x.ResultDescription).HasColumnName("Result_Description");
        }
        private void SetRoleSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().Property(x => x.UserID).HasColumnName("User_ID");
            modelBuilder.Entity<Role>().Property(x => x.RoleTypeID).HasColumnName("RoleType_ID");
            modelBuilder.Entity<Role>().HasKey(x => new { x.UserID, x.RoleTypeID });
        }
    }
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
