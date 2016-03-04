namespace YouTubePlaylists.Data
{
	using System.Data.Entity;
	using System.Data.Entity.Infrastructure;

	using YouTubePlaylists.Models;

	public interface IYouTubePlaylistsDbContext
	{

		IDbSet<User> Users { get; set; }

        IDbSet<Playlist> Playlists { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        IDbSet<Video> Videos { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
			where TEntity : class;

		void Dispose();

		int SaveChanges();
	}
}