using FluentMigrator;
using System.Data;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(20230430203800)]
    public class AddDisabledProducts : Migration
    {
        public override void Up()
        {
            Create.Table("DisabledProducts")
                .WithColumn("DisabledProduct_ID").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Product_ID").AsInt32().NotNullable()

                .ForeignKey("FK_DisabledProducts_Products_Product_ID", "Products", "Product_ID")
                .OnDeleteOrUpdate(Rule.Cascade)
                .Indexed("IX_DisabledProducts_Product_ID")

                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("Reason").AsString(100).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("DisabledProducts");
        }
    }
}
