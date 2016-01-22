namespace Template.Web
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TemplateDbContext, Configuration>());
            TemplateDbContext.Create().Database.Initialize(true);
        }
    }
}