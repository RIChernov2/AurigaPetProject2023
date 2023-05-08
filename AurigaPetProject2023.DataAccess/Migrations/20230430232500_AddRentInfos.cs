using FluentMigrator;
using System.Data;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230430232500)]
    public class AddRentInfos : Migration
    {
        public override void Up()
        {
            Create.Table("RentInfos")
                .WithColumn("RentInfo_ID").AsInt32().PrimaryKey().Identity().NotNullable()

                .WithColumn("User_ID").AsInt32().NotNullable()
                .ForeignKey("FK_RentInfo_Users_User_ID", "Users", "User_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_RentInfo_User_ID")

                .WithColumn("Item_ID").AsInt32().NotNullable()
                .ForeignKey("FK_RentInfo_Items_Item_ID", "Items", "Item_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_RentInfo_Item_ID")

                .WithColumn("Start_Date").AsDateTime().NotNullable()
                .WithColumn("Expire_Date").AsDateTime().NotNullable()

                .WithColumn("End_Date").AsDateTime().Nullable()
                .Indexed("IX_RentInfo_End_Date")

                .WithColumn("Cost").AsDouble().NotNullable()

                .WithColumn("IsPaid").AsBoolean().NotNullable()
                .Indexed("IX_RentInfo_Is_Paid");
        }

        public override void Down()
        {
            Delete.Table("RentInfos");
        }
    }
}
