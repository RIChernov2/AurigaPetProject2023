using FluentMigrator;


namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230406012500)]
    public class AddProductTypes : Migration
    {
        public override void Up()
        {
            Create.Table("ProductTypes")
                .WithColumn("Product_Type_ID").AsInt64().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Unique").AsBoolean();

            //Create.Index("IX_Users_LastName")
            //    .OnTable("Users")
            //    .OnColumn("Last_Name");

            //Create.Index("IX_Users_Email")
            //    .OnTable("Users")
            //    .OnColumn("Email");
        }

        public override void Down()
        {
            Delete.Table("ProductTypes");
        }
    }
}
