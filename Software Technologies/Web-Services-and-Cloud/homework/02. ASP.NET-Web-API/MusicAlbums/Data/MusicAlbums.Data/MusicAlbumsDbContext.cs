namespace MusicAlbums.Data
{
    using System.Data.Entity;
    using Models;
    using Migrations;
    using System;

    public class MusicAlbumsDbContext : DbContext, IMusicAlbumsDbContext
    {
        public MusicAlbumsDbContext()
            : base("MusicAlbumsConnection")
        {
        }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        IDbSet<T> IMusicAlbumsDbContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}