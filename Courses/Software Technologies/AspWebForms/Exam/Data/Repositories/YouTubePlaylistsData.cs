namespace YouTubePlaylists.Data.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;

	using YouTubePlaylists.Models;

	public class YouTubePlaylistsData : IYouTubePlaylistsData
	{
		private readonly DbContext context;
		private readonly IDictionary<Type, object> repositories;

		public YouTubePlaylistsData()
		{
			this.context = new YouTubePlaylistsDbContext();
			this.repositories = new Dictionary<Type, object>();
		}

		public IRepository<User> Users
		{
			get
			{
				return this.GetRepository<User>();
			}
		}

        public IRepository<Playlist> Playlists
        {
            get
            {
                return this.GetRepository<Playlist>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Rating> Ratings
        {
            get
            {
                return this.GetRepository<Rating>();
            }
        }

        public IRepository<Video> Videos
        {
            get
            {
                return this.GetRepository<Video>();
            }
        }

        public int SaveChanges()
		{
			return this.context.SaveChanges();
		}

		private IRepository<T> GetRepository<T>() where T : class
		{
			var typeOfRepository = typeof(T);

			if (!this.repositories.ContainsKey(typeOfRepository))
			{
				var newRepository = Activator.CreateInstance(typeof(EfRepository<T>), this.context);
				this.repositories.Add(typeOfRepository, newRepository);
			}

			return (IRepository<T>)this.repositories[typeOfRepository];
		}
	}
}