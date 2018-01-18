namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        private ICollection<Image> images;

        private ICollection<Post> posts;

        public User()
        {
            this.images = new HashSet<Image>();
            this.posts = new HashSet<Post>();
        }

        public int UserId { get; set; }

        [Required]
        [MaxLength(20)]
        [Index(IsUnique = true)]        
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return images; }
            set { images = value; }
        }

        public virtual ICollection<Post> Posts
        {
            get { return posts; }
            set { posts = value; }
        }
    }
}