namespace SimpleTwitter.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface ISimpleTwitterDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Tweet> Tweets { get; set; }

        IDbSet<HashTag> HashTags { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}