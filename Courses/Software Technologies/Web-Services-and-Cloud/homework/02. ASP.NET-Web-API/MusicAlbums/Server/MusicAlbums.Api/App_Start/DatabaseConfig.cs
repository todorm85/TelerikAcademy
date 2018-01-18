

namespace MusicAlbums.Api.App_Start
{
    using System.Data.Entity;
    using MusicAlbums.Data;
    using MusicAlbums.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicAlbumsDbContext, Configuration>());

            new MusicAlbumsDbContext().Database.Initialize(true);
        }
    }
}
