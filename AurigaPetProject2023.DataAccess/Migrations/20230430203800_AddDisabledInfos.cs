using FluentMigrator;
using System.Data;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230430203800)]
    public class AddDisabledInfos : Migration
    {
        public override void Up()
        {
            Create.Table("DisabledInfos")
                .WithColumn("DisabledInfo_ID").AsInt32().PrimaryKey().Identity().NotNullable()

                .WithColumn("Item_ID").AsInt32().NotNullable()
                .ForeignKey("FK_DisabledInfos_Items_Item_ID", "Items", "Item_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_DisabledInfos_Item_ID")

                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("Reason").AsString(100).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("DisabledInfos");
        }
    }
}
