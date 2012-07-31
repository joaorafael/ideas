using Migrator.Framework;
using System.Data;

namespace WebIdeas.Migrations
{

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

    [Migration(201207311225)]
    public class InsertInitialTagRecords_002 : Migration
    {
        public override void Up()
        {
            Database.Insert("Tag", new string[] { "Name" }, new string[] { "Papel" });
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

    [Migration(201207311725)]
    public class CreateContributerTable_003 : Migration
    {
        public override void Up()
        {
            Database.ExecuteNonQuery(
                @"create table [Contributer] (
                   Id INT IDENTITY NOT NULL,
                   Name NVARCHAR(255) null,
                   primary key (Id)
                )");
        }

        public override void Down()
        {
            Database.RemoveTable("Contributer");
        }
    }

    [Migration(201207311226)]
    public class InsertInitialContributerRecords_004 : Migration
    {
        public override void Up()
        {
            Database.Insert("Contributer", new string[] { "Name" }, new string[] { "Bárbara" });
            Database.Insert("Contributer", new string[] { "Name" }, new string[] { "César" });
            Database.Insert("Contributer", new string[] { "Name" }, new string[] { "Rocha" });
            Database.Insert("Contributer", new string[] { "Name" }, new string[] { "Virgínio" });
        }

        public override void Down()
        {
            Database.Delete("Contributer", "Name", "Bárbara");
            Database.Delete("Contributer", "Name", "César");
            Database.Delete("Contributer", "Name", "Rocha");
            Database.Delete("Contributer", "Name", "Virgínio");
        }
    }

    [Migration(201207311816)]
    public class CreateIdeaTable_003 : Migration
    {
        public override void Up()
        {
            Database.ExecuteNonQuery(
                @"create table [Idea] (
                   Id INT IDENTITY NOT NULL,
                   Text NVARCHAR(255) null,
                   primary key (Id)
                )");
        }

        public override void Down()
        {
            Database.RemoveTable("Idea");
        }
    }

    [Migration(201207311817)]
    public class InsertInitialIdeaRecords_004 : Migration
    {
        public override void Up()
        {
            Database.Insert("Idea", new string[] { "Text" }, new string[] { "Ideia marada" });
            Database.Insert("Idea", new string[] { "Text" }, new string[] { "Olha que boa ideia" });
            Database.Insert("Idea", new string[] { "Text" }, new string[] { "Não sei porquê mas parece-me boa ideia" });
        }

        public override void Down()
        {
            Database.Delete("Idea", "Text", "Ideia marada");
            Database.Delete("Idea", "Text", "Olha que boa ideia");
            Database.Delete("Idea", "Text", "Não sei porquê mas parece-me boa ideia");
        }
    }
}