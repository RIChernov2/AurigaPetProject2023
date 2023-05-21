using FluentMigrator;
using System.Data;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230521235000)]
    public class AddDiscountInfos : Migration
    {
        public override void Up()
        {
            Create.Table("DiscountInfos")
                .WithColumn("User_ID").AsInt32().NotNullable()
                .ForeignKey("FK_DiscountInfos_Users_User_ID", "Users", "User_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_RentInfos_User_ID")

                .WithColumn("DiscountPercentage").AsByte().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("DiscountInfos");
        }
    }
}
