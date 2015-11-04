namespace MusicAlbums.Data
{
    using Models;
    using Repositories;

    public interface IMusicAlbumsData
    {
        IGenericRepository<Artist> Artists { get; }

        IGenericRepository<Song> Songs { get; }

        IGenericRepository<Album> Albums { get; }

        void SaveChanges();
    }
}