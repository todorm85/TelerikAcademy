namespace YouTubePlaylists.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public User()
        {
            this.AppRoles = new HashSet<AppRole>();
            this.ImageUrl = "http://i2.mirror.co.uk/incoming/article6379795.ece/ALTERNATES/s615b/Minion.jpg";
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FacebookUrl { get; set; }

        public string YouTubeUrl { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<AppRole> AppRoles { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}