namespace YouTubePlaylists.Data.Repositories
{
	using YouTubePlaylists.Models;

	public interface IYouTubePlaylistsData
	{
		IRepository<User> Users { get; }

        IRepository<Playlist> Playlists { get; }

        IRepository<Category> Categories { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<Video> Videos { get; }

        int SaveChanges();
	}
}