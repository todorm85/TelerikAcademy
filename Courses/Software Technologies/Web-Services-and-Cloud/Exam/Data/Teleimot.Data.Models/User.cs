namespace Teleimot.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        private ICollection<Estate> estates;
        private ICollection<Comment> comments;
        private ICollection<Rating> ratings;

        public User()
        {
            this.estates = new HashSet<Estate>();
            this.comments = new HashSet<Comment>();
            this.ratings = new HashSet<Rating>();
        }

        [MaxLength(ValidationConstants.UsernameMaxLength)]
        public string ProvidedUsername { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get
            {
                return this.ratings;
            }

            set
            {
                this.ratings = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }

        public virtual ICollection<Estate> Estates
        {
            get
            {
                return this.estates;
            }

            set
            {
                this.estates = value;
            }
        }

        // added by framework
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }
    }
}