using FluentMigrator;
using System.Data;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230507052300)]
    public class AddItemUniqueInfos : Migration
    {
        public override void Up()
        {
            Create.Table("ItemUniqueInfos")
                .WithColumn("ItemUnique_ID").AsInt32().PrimaryKey().Identity().NotNullable()

                .WithColumn("Item_ID").AsInt32().NotNullable()
                .ForeignKey("FK_ItemUniqueInfos_Items_Item_ID", "Items", "Item_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_ItemUniqueInfos_Item_ID");
        }

        public override void Down()
        {
            Delete.Table("ItemUniqueInfos");
        }
    }
}
