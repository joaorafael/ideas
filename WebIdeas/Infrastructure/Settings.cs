namespace WebIdeas.Infrastructure
{
    public class Settings
    {
        public static string SqlConnectionStringMaster = @"Server=.\SQLExpress;Database=master;Trusted_Connection=True;";
        public static string SqlConnectionStringTests = @"Server=.\SQLExpress;Database=test;Trusted_Connection=True;";
    }
}