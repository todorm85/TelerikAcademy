namespace MusicAlbums.Data
{
    using MusicAlbums.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IMusicAlbumsDbContext
    {
        IDbSet<Album> Albums { get; set; }

        IDbSet<Artist> Artists { get; set; }

        IDbSet<Song> Songs { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
