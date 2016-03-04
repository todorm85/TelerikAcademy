namespace SimpleTwitter.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Tweet
    {
        public Tweet()
        {
            HashTags = new HashSet<HashTag>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<HashTag> HashTags { get; set; }
    }
}