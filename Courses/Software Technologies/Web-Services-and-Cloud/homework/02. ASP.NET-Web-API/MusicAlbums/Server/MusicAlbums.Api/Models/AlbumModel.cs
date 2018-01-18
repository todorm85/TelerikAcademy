namespace MusicAlbums.Api.Models
{
    using MusicAlbums.Api.Infrastructure.Mappings;
    using MusicAlbums.Models;

    public class AlbumModel : IMapFrom<Album>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? Year { get; set; }

        public string Producer { get; set; }
    }
}