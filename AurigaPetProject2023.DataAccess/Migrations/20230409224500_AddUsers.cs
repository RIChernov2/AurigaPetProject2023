using FluentMigrator;
using System.Data;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230409224500)]
    public class AddUsers : Migration
    {
        public override void Up()
        {
            // поля нельзя сделать unique + null
            // уникальность логина и телефона надо проверять при создании
            Create.Table("Users")
                .WithColumn("User_ID").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Login_Name").AsString(20).Nullable()
                .WithColumn("Phone").AsString(20).Nullable()
                .WithColumn("Password").AsString(64).NotNullable();


            Create.Table("RoleTypes")
                .WithColumn("RoleType_ID").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(50).NotNullable();

            Create.Table("Roles")
                .WithColumn("User_ID").AsInt32().NotNullable()
                .WithColumn("RoleType_ID").AsInt32().NotNullable();


            Create.ForeignKey("FK_Roles_Users_User_ID")
                .FromTable("Roles").ForeignColumn("User_ID")
                .ToTable("Users").PrimaryColumn("User_ID")
                .OnDeleteOrUpdate(Rule.Cascade);

            Create.ForeignKey("FK_Roles_RoleTypes_RoleType_ID")
                .FromTable("Roles").ForeignColumn("RoleType_ID")
                .ToTable("RoleTypes").PrimaryColumn("RoleType_ID")
                .OnDeleteOrUpdate(Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("Users");
        }
    }
}
