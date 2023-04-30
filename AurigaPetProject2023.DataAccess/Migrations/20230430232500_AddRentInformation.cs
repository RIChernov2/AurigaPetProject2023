using FluentMigrator;
using System.Data;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230430232500)]
    public class AddRentInformation : Migration
    {
        public override void Up()
        {
            Create.Table("RentInformation")
                .WithColumn("RentInformation_ID").AsInt32().PrimaryKey().Identity().NotNullable()

                .WithColumn("User_ID").AsInt32().NotNullable()
                .ForeignKey("FK_RentInformation_Users_User_ID", "Users", "User_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_RentInformation_User_ID")

                .WithColumn("Product_ID").AsInt32().NotNullable()
                .ForeignKey("FK_RentInformation_Products_Product_ID", "Products", "Product_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_RentInformation_Product_ID")

                .WithColumn("Start_Date").AsDateTime().NotNullable()
                .WithColumn("Expire_Date").AsDateTime().NotNullable()

                .WithColumn("End_Date").AsDateTime().Nullable()
                .Indexed("IX_RentInformation_End_Date")

                .WithColumn("Cost").AsDouble().NotNullable()

                .WithColumn("IsPaid").AsBoolean().NotNullable()
                .Indexed("IX_RentInformation_Is_Paid");
        }

        public override void Down()
        {
            Delete.Table("RentInformation");
        }
    }
}
