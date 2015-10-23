namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using SocialNetwork.ConsoleClient.XmlImporter;
    using SocialNetwork.Data;
    using SocialNetwork.Data.Migrations;

    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());

            // Please close your SqlServer ManagementStudio app entirely for this to work.
            CreateNewDatabase();

            ImportXmlFiles();
        }

        private static void ImportXmlFiles()
        {
            Console.WriteLine("Importing XML data");
            var xmlData = new XmlData();

            Console.WriteLine("Importing test friendships");
            xmlData.ImportAllFriendships(@"..\..\XmlFiles\Friendships-Test.xml");

            Console.WriteLine("Importing friendships");
            xmlData.ImportAllFriendships(@"..\..\XmlFiles\Friendships.xml");

            Console.WriteLine("Importing test posts");
            xmlData.ImportAllPosts(@"..\..\XmlFiles\Posts-Test.xml");

            Console.WriteLine("Importing posts. Please be patient, they are just toooo many. Around 4-5 min.");
            xmlData.ImportAllPosts(@"..\..\XmlFiles\Posts.xml");

        }

        private static void CreateNewDatabase()
        {
            var db = new SocialNetworkDbContext();
            db.Database.Delete();
            db.Database.Create();
        }
    }
}
