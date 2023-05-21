using FluentMigrator;
using System.Data;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230522001800)]
    public class AddBannedInfos : Migration
    {
        public override void Up()
        {
            Create.Table("BannedInfos")
                .WithColumn("BannedInfo_ID").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("User_ID").AsInt32().NotNullable()
                .ForeignKey("FK_BannedInfos_Users_User_ID", "Users", "User_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_BannedInfos_User_ID")

                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("Reason").AsString(100).NotNullable();

        }

        public override void Down()
        {
            Delete.Table("BannedInfos");
        }
    }
}
