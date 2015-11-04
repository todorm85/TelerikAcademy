namespace MusicAlbums.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure.Mappings;
    using MusicAlbums.Models;

    public class ArtistModel : IMapFrom<Artist>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
