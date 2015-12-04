namespace Teleimot.Server.Api
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DataConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TeleimotDbContext, Configuration>());
            TeleimotDbContext.Create().Database.Initialize(true);
        }
    }
}