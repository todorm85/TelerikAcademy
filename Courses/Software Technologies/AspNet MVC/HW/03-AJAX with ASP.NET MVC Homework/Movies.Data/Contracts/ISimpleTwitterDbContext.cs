namespace Movies.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface ISimpleTwitterDbContext
    {
        //IDbSet<HashTag> HashTags { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}