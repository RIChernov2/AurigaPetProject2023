using Microsoft.EntityFrameworkCore;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Helpers;
using System.Linq.Expressions;
using System;

namespace AurigaPetProject2023.DataAccess.Repositories
{
    public class NewContext : DbContext
    {
        public DbSet<ProductType> ProductTypes { get; set; } = null;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = DateBaseHelper.GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
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
