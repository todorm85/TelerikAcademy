namespace Teleimot.Server.Api.Tests.Setups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Data.Contracts;
    using Moq;

    public static class Repositories
    {
        public static IRepository<User> GetUsersRepository()
        {
            var userRepository = new Mock<IRepository<User>>();

            userRepository.Setup(x => x.All())
                .Returns(() =>
                {
                    return new List<User>
                    {
                        new User { Id = "1", ProvidedUsername ="TestUser1",
                            Comments = new List<Comment>
                            {
                                new Comment { CreatedOn = DateTime.Now },
                                new Comment { CreatedOn = DateTime.Now + TimeSpan.FromDays(3)},
                                new Comment { CreatedOn = DateTime.Now + TimeSpan.FromDays(1)},
                                new Comment { CreatedOn = DateTime.Now + TimeSpan.FromDays(2)},
                            }
                        },
                    }.AsQueryable();
                });

            return userRepository.Object;
        }

        public static IRepository<Comment> GetCommentsRepository()
        {
            var userRepository = new Mock<IRepository<Comment>>();

            userRepository.Setup(x => x.All())
                .Returns(() =>
                {
                    return new List<Comment>
                    {
                        new Comment { User = new User { ProvidedUsername = "User1"},  }
                    }.AsQueryable();
                });

            return userRepository.Object;
        }
    }
}
