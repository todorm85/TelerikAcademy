namespace Movies
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Movies.Data;
    using Movies.Data.Migrations;
    using Movies.Data.Models;

    internal class DatabaseConfig
    {
        public static void Config()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SimpleTwitterDbContext, Configuration>());
            SimpleTwitterDbContext.Create().Database.Initialize(true);

            Seed();
        }

        public static void Seed()
        {
            var context = new SimpleTwitterDbContext();
        }
    }
}