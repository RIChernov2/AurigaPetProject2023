using AurigaPetProject2023.DataAccess.Helpers;
using FluentMigrator;


namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(99999999999999)]
    public class InitialDataMigration : Migration
    {
        public override void Up()
        {
            AddProductTypes();
            AddUsers();

        }

        public override void Down()
        {
        }

        private void AddProductTypes()
        {
            Insert.IntoTable("ProductTypes")
                .Row(new { Name = "Нож", Unique = "0" })
                .Row(new { Name = "Фонарь", Unique = "false" })
                .Row(new { Name = "Топор", Unique = "false" })
                .Row(new { Name = "Гамак", Unique = "1" })
                .Row(new { Name = "Палатка", Unique = "true" })
                .Row(new { Name = "Теннисные ракетки", Unique = "false" });
        }
        private void AddUsers()
        {
            Insert.IntoTable("Users")
                .Row(new { Login_Name = "Manager", Password = $"{HashHelper.GetHash("123")}" })
                .Row(new { Login_Name = "User", Password = $"{HashHelper.GetHash("111")}" })
                .Row(new { Login_Name = "User2", Password = $"{HashHelper.GetHash("222")}" })
                .Row(new { Login_Name = "User3", Password = $"{HashHelper.GetHash("333")}" })
                .Row(new { Login_Name = "Boss", Phone = "+79261234567", Password = $"{HashHelper.GetHash("777")}" });

            Insert.IntoTable("RoleTypes")
                .Row(new { Name = "Администратор" })
                .Row(new { Name = "Менеджер" })
                .Row(new { Name = "Пользователь" });

            Insert.IntoTable("Roles")
                .Row(new { User_ID = "1", RoleType_ID = "2" })
                .Row(new { User_ID = "2", RoleType_ID = "3" })
                .Row(new { User_ID = "3", RoleType_ID = "3" })
                .Row(new { User_ID = "4", RoleType_ID = "3" })
                .Row(new { User_ID = "5", RoleType_ID = "1" })
                .Row(new { User_ID = "5", RoleType_ID = "2" });
        }
    }
}
