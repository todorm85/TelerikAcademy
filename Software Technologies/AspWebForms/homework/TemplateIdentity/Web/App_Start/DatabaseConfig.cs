namespace SolutionTemplate.Web
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SolutionTemplateDbContext, Configuration>());
            SolutionTemplateDbContext.Create().Database.Initialize(true);
        }
    }
}