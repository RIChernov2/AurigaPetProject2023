using FluentMigrator;
using System.Data;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230507052300)]
    public class AddUniqueIds : Migration
    {
        public override void Up()
        {
            Create.Table("UniqueIds")
                .WithColumn("UniqueID").AsInt32().PrimaryKey().Identity().NotNullable()

                .WithColumn("Product_ID").AsInt32().NotNullable()
                .ForeignKey("FK_UniqueIds_Products_Product_ID", "Products", "Product_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_UniqueIds_Product_ID");
        }

        public override void Down()
        {
            Delete.Table("UniqueIds");
        }
    }
}
