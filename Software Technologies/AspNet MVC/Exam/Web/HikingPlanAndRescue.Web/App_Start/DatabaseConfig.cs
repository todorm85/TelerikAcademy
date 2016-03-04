namespace VoiceSystem.Web
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Config()
        {
            var dbReset = false;
            if (dbReset)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
            }
            else
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            }

            ApplicationDbContext.Create().Database.Initialize(true);
        }
    }
}