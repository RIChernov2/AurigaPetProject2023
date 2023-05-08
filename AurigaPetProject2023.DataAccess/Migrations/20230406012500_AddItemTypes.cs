using FluentMigrator;


namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230406012500)]
    public class AddItemTypes : Migration
    {
        public override void Up()
        {
            Create.Table("ItemTypes")
                .WithColumn("ItemType_ID").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Unique").AsBoolean();
        }

        public override void Down()
        {
            Delete.Table("ItemTypes");
        }
    }
}
