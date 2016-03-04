namespace YouTubePlaylists.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        public Category()
        {
            this.Playlists = new HashSet<Playlist>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(128)]
        public string Name { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
