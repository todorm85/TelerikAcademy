namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        private ICollection<User> users;

        public Post()
        {
            this.users = new HashSet<User>();
        }

        public int PostId { get; set; }

        [Required]
        public string PostContent { get; set; }

        public DateTime PostDate { get; set; }

        public virtual ICollection<User> Users
        {
            get { return users; }
            set { users = value; }
        }
    }
}