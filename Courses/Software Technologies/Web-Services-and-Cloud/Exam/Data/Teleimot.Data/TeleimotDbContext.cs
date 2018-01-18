namespace Teleimot.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class TeleimotDbContext : IdentityDbContext<User>, IDbContext
    {
        public TeleimotDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Estate> Estates { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public static TeleimotDbContext Create()
        {
            return new TeleimotDbContext();
        }

        DbEntityEntry IDbContext.Entry<T>(T entity)
        {
            return this.Entry<T>(entity);
        }

        IDbSet<T> IDbContext.Set<T>()
        {
            return this.Set<T>();
        }
    }
}