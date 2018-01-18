namespace Teleimot.Services.Data.Contracts
{
    using System.Linq;
    using Teleimot.Data.Models;

    public interface IUsersService
    {
        User RateUser(string userId, double value);

        User GetUserDetails(string username);

        IQueryable<User> GetUsers();
    }
}