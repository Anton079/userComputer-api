using FluentMigrator;
using System.Data;

namespace UserComputer_api.Data.Migrations
{
    [Migration(15052025)]
    public class CreateSchemaUserComputerTables:Migration
    {
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("email").AsString().NotNullable()
                .WithColumn("password").AsString().NotNullable()
                .WithColumn("phone").AsInt32().NotNullable();

            Create.Table("computers")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("type").AsString().NotNullable()
                .WithColumn("model").AsString().NotNullable()
                .WithColumn("price").AsInt32().NotNullable()
                .WithColumn("UserId").AsInt32().ForeignKey("users", "id").OnDelete(Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("users");
            Delete.Table("computers");
        }
    }
}
