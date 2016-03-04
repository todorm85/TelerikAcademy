namespace YouTubePlaylists.Web
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            //Database.Delete("YouTubePlaylists");
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<YouTubePlaylistsDbContext, Configuration>());
            YouTubePlaylistsDbContext.Create().Database.Initialize(true);
        }
    }
}