namespace BullsAndCows.Services.Data
{
    using System.Linq;
    using BullsAndCows.Data.Contracts;
    using BullsAndCows.Data.Models;
    using Contracts;

    public class UsersService : IUsersService
    {
        private IUow uow;

        public UsersService(IUow uow)
        {
            this.uow = uow;
        }

        public User UserByUserId(string userId)
        {
            return this.uow.Users.All().FirstOrDefault(u => u.Id == userId);
        }

        public User UserByUsername(string username)
        {
            return this.uow.Users.All().FirstOrDefault(u => u.UserName == username);
        }

        public string UserIdByUsername(string username)
        {
            var user = this.UserByUsername(username);
            if (user == null)
            {
                return null;
            }

            return user.Id;
        }
    }
}