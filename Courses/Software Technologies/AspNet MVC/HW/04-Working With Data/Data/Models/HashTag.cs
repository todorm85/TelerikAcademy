namespace SimpleTwitter.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class HashTag
    {
        public HashTag()
        {
            Tweets = new HashSet<Tweet>();
        }

        [Key]
        public string Name { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}