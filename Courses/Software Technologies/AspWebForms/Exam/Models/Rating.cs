namespace YouTubePlaylists.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Rating
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        [Key, Column(Order = 1)]
        public int PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }

        public virtual User User { get; set; }

        [Required]
        [Range(1,5)]
        public int Value { get; set; }
    }
}