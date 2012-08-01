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
            Database.ExecuteNonQuery(@"insert into Contributer (Name) values ('Bárbara');");
            Database.ExecuteNonQuery(@"insert into Contributer (Name) values ('César');");
            Database.ExecuteNonQuery(@"insert into Contributer (Name) values ('Rocha');");
            Database.ExecuteNonQuery(@"insert into Contributer (Name) values ('Virgínio');");
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
    public class CreateIdeaTable_005 : Migration
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
    public class InsertInitialIdeaRecords_006 : Migration
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

    [Migration(201208011612)]
    public class AddColumnsToIdea_007 : Migration
    {
        public override void Up()
        {
            Database.ExecuteNonQuery(@"alter table [Idea] add Date DATETIME default getDate()  not null;");
            Database.ExecuteNonQuery(@"alter table [Idea] add Contributer_id INT null;");
            Database.ExecuteNonQuery(@"alter table [Idea] add Tag_id INT null;");
            Database.ExecuteNonQuery(@"alter table [Idea] add Title NVARCHAR(255) null;");
        }

        public override void Down()
        {
            Database.ExecuteNonQuery(@"alter table [Idea] drop column Date;");
            Database.ExecuteNonQuery(@"alter table [Idea] drop column Contributer_id;");
            Database.ExecuteNonQuery(@"alter table [Idea] drop column Tag_id;");
            Database.ExecuteNonQuery(@"alter table [Idea] drop column Title;");
        }
    }

    [Migration(201208011618)]
    public class AddConstraintsToIdea_008 : Migration
    {
        public override void Up()
        {
            Database.ExecuteNonQuery(@"alter table [Idea] add constraint FK_Idea_Contributer foreign key (Contributer_id) references [Contributer];");
            Database.ExecuteNonQuery(@"alter table [Idea] add constraint FK_Idea_Tag foreign key (Tag_id) references [Tag];");
        }

        public override void Down()
        {
            Database.ExecuteNonQuery(@"alter table [Idea] drop constraint FK_Idea_Contributer;");
            Database.ExecuteNonQuery(@"alter table [Idea] drop constraint FK_Idea_Tag;");
        }
    }

    [Migration(201208011620)]
    public class UpdateIdeasValues_009 : Migration
    {
        public override void Up()
        {
            Database.ExecuteNonQuery(@"update [Idea] set Contributer_id = 1, Tag_id = 1, Title = 'Title disto' where id = 1;");
            Database.ExecuteNonQuery(@"update [Idea] set Contributer_id = 2, Tag_id = 2, Title = 'O título' where id = 2;");
            Database.ExecuteNonQuery(@"update [Idea] set Contributer_id = 3, Tag_id = 2, Title = 'Say what?' where id = 3;");
        }

        public override void Down()
        {
            Database.ExecuteNonQuery(@"update [Idea] set Contributer_id = null, Tag_id = null, Title = null where id = 1;");
            Database.ExecuteNonQuery(@"update [Idea] set Contributer_id = null, Tag_id = null, Title = null where id = 2;");
            Database.ExecuteNonQuery(@"update [Idea] set Contributer_id = null, Tag_id = null, Title = null where id = 3;");
        }
    }
}