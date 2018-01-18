namespace Movies.Data.Contracts
{
    using Repositories;

    public interface ISimpleTwitterData
    {
        //IRepository<Tweet> Tweets { get; }

        int SaveChanges();
    }
}