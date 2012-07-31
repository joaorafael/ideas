using Migrator.Framework;
using System.Data;

namespace WebIdeas.Migrations
{
    [Migration(201207311225)]
    public class InsertInitialTagRecords_002 : Migration
    {
        public override void Up()
        {
            Database.Insert("Tag", new string[] {"Name"}, new string[] {"Papel"});
            Database.Insert("Tag", new string[] { "Name" }, new string[] { "WC" });
            Database.Insert("Tag", new string[] { "Name" }, new string[] { "Secretárias" });
            Database.Insert("Tag", new string[] { "Name" }, new string[] { "Cadeiras" });
            Database.Insert("Tag", new string[] { "Name" }, new string[] { "Portáteis" });
        }

        public override void Down()
        {
            Database.Delete("Tag", "Name", "Papel");
            Database.Delete("Tag", "Name", "WC");
            Database.Delete("Tag", "Name", "Secretárias");
            Database.Delete("Tag", "Name", "Cadeiras");
            Database.Delete("Tag", "Name", "Portáteis");
        }
    }

    [Migration(201207311136)]
    public class CreateTagTable_001 : Migration
    {
        public override void Up()
        {
            Database.ExecuteNonQuery(
                @"create table [Tag] (
                    Id INT IDENTITY NOT NULL,
                   Name NVARCHAR(255) null,
                   primary key (Id)
                )");
        }

        public override void Down()
        {
            Database.RemoveTable("Tag");
        }
    }
}