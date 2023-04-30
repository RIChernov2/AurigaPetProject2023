using FluentMigrator;
using System.Data;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230430192800)]
    public class AddUnderRepairProducts : Migration
    {
        public override void Up()
        {
            Create.Table("UnderRepairProducts")
                .WithColumn("RepairProduct_ID").AsInt32().PrimaryKey().Identity().NotNullable()

                .WithColumn("Product_ID").AsInt32().NotNullable()
                .ForeignKey("FK_UnderRepairProducts_Products_Product_ID", "Products", "Product_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_UnderRepairProducts_Product_ID")

                .WithColumn("Start_Date").AsDateTime().NotNullable()

                .WithColumn("End_Date").AsDateTime().Nullable()
                .Indexed("IX_UnderRepairProducts_End_Date")
                
                .WithColumn("Reason").AsString(100).NotNullable()
                .WithColumn("ResultDescription").AsString(100).Nullable();


        }

        public override void Down()
        {
            Delete.Table("UnderRepairProducts");
        }
    }
}
