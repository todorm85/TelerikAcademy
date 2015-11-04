namespace MusicAlbums.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mappings;
    using MusicAlbums.Models;

    public class SongModel : IMapFrom<Song>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? Year { get; set; }

        public string Genre { get; set; }

        public int ArtistId { get; set; }

        public int AlbumId { get; set; }
    }
}