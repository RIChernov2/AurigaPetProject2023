using FluentMigrator;
using System.Data;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230430191200)]
    public class AddItems : Migration
    {
        public override void Up()
        {
            Create.Table("Items")
                .WithColumn("Item_ID").AsInt32().PrimaryKey().Identity().NotNullable()

                .WithColumn("ItemType_ID").AsInt32().NotNullable()
                .ForeignKey("FK_Items_ItemTypes_ItemType_ID", "ItemTypes", "ItemType_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_Items_ItemType_ID")

                .WithColumn("Description").AsString(100).Nullable();

            //Create.Index("IX_Products_ProductType_ID")
            //    .OnTable("Products")
            //    .OnColumn("ProductType_ID");

        }

        public override void Down()
        {
            Delete.Table("Items");
        }
    }
}
