namespace SimpleTwitter.Data.Contracts
{
    using Models;
    using Repositories;

    public interface ISimpleTwitterData
    {
        IRepository<User> Users { get; }

        IRepository<HashTag> HashTags { get; }

        IRepository<Tweet> Tweets { get; }

        int SaveChanges();
    }
}