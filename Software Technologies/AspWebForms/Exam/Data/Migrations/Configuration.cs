namespace YouTubePlaylists.Data.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	using System.Linq;

	using Microsoft.AspNet.Identity;

	using YouTubePlaylists.Data;
	using YouTubePlaylists.Models;

	public sealed class Configuration : DbMigrationsConfiguration<YouTubePlaylistsDbContext>
    {
        public Configuration()
        {
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

        protected override void Seed(YouTubePlaylistsDbContext context)
        {
            DbSeeder.Seed(context);
        }
	}
}
