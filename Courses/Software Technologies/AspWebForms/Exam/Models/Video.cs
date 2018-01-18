namespace YouTubePlaylists.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Video
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int? PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }

    }
}
