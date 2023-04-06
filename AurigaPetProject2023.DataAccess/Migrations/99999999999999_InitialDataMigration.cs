using FluentMigrator;


namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(99999999999999)]
    public class InitialDataMigration : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("ProductTypes")
                .Row(new { Name = "Нож", Unique = "0" })
                .Row(new { Name = "Фонарь", Unique = "false" })
                .Row(new { Name = "Топор", Unique = "false" })
                .Row(new { Name = "Гамак", Unique = "1" })
                .Row(new { Name = "Палатка", Unique = "true" })
                .Row(new { Name = "Теннисные ракетки", Unique = "false" });
        }

        public override void Down()
        {
        }
    }
}
