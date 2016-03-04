namespace Movies.Data.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	using System.Linq;

	using Microsoft.AspNet.Identity;

	using Movies.Data;

	public sealed class Configuration : DbMigrationsConfiguration<SimpleTwitterDbContext>
    {
        public Configuration()
        {
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}
	}
}
