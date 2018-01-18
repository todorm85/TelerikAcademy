namespace Teleimot.Data.Contracts
{
    using Teleimot.Data.Models;

    public interface ITeleimotData
    {
        IRepository<User> Users { get; }

        IRepository<Estate> Estates { get; }

        IRepository<Comment> Comments { get; }

        void SaveChanges();
    }
}