namespace Teleimot.Services.Data
{
    using System.Linq;
    using Teleimot.Data.Contracts;
    using Teleimot.Data.Models;
    using Contracts;
    using System;

    public class UsersService : IUsersService
    {
        private ITeleimotData data;
        private const int PageSize = 10;

        public UsersService(ITeleimotData data)
        {
            this.data = data;
        }

        public User RateUser(string userId, double value)
        {
            var targetUser = this.data.Users.All().FirstOrDefault(x => x.Id == userId);
            if (targetUser == null)
            {
                return null;
            }

            targetUser.Ratings.Add(new Rating() { Value = value});
            this.data.SaveChanges();

            return targetUser;
        }

        public User GetUserDetails(string username)
        {
            var user = this.data.Users.All().FirstOrDefault(x => x.ProvidedUsername == username);

            return user;
        }

        public IQueryable<User> GetUsers()
        {
            return this.data.Users.All();
        }
    }
}