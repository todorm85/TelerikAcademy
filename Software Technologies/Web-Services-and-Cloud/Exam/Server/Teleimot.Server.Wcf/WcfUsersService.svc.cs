namespace Teleimot.Server.Wcf
{
    using System.Collections.Generic;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.User;
    using Services.Data;
    using Services.Data.Contracts;
    using System.Linq;

    public class WcfUsersService : IWcfUsersService
    {
        private IUsersService usersService;
            

        public WcfUsersService()
        {
            this.usersService = new UsersService(new TeleimotData(new TeleimotDbContext()));
        }

        public IEnumerable<object> GetTopUsers()
        {
            var users = this.usersService.GetUsers()
                .ProjectTo<UserResponseModel>()
                .ToList()
                .OrderByDescending(x => x.Rating)
                .Take(10)
                .Select(x => new { Username = x.Username, Rating = x.Rating });

            return users;
        }
    }
}