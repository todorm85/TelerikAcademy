namespace YouTubePlaylists.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Playlist
    {
        public Playlist()
        {
            this.Videos = new HashSet<Video>();
            this.Ratings = new HashSet<Rating>();
            this.CreationDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<Video> Videos { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

    }
}