using FluentMigrator;
using System.Data;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230430191200)]
    public class AddProducts : Migration
    {
        public override void Up()
        {
            Create.Table("Products")
                .WithColumn("Product_ID").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("ProductType_ID").AsInt32().NotNullable()

                .ForeignKey("FK_Products_ProductTypes_ProductType_ID", "ProductTypes", "ProductType_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_Products_ProductType_ID")

                .WithColumn("Description").AsString(100).Nullable();

            //Create.Index("IX_Products_ProductType_ID")
            //    .OnTable("Products")
            //    .OnColumn("ProductType_ID");

        }

        public override void Down()
        {
            Delete.Table("Products");
        }
    }
}
