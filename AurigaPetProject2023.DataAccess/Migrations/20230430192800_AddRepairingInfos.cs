using FluentMigrator;
using System.Data;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230430192800)]
    public class AddRepairingInfos : Migration
    {
        public override void Up()
        {
            Create.Table("RepairingInfos")
                .WithColumn("RepairItem_ID").AsInt32().PrimaryKey().Identity().NotNullable()

                .WithColumn("Item_ID").AsInt32().NotNullable()
                .ForeignKey("FK_RepairingInfos_Items_Item_ID", "Items", "Item_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_RepairingInfos_Item_ID")

                .WithColumn("Start_Date").AsDateTime().NotNullable()

                .WithColumn("End_Date").AsDateTime().Nullable()
                .Indexed("IX_RepairingInfos_End_Date")
                
                .WithColumn("Reason").AsString(100).NotNullable()
                .WithColumn("ResultDescription").AsString(100).Nullable();


        }

        public override void Down()
        {
            Delete.Table("RepairingInfos");
        }
    }
}
