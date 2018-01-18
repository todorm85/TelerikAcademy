namespace Teleimot.Server.Api.Tests.Setups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Teleimot.Services.Data;
    using Teleimot.Services.Data.Contracts;
    using Data;

    public class Services
    {
        public static IUsersService GetUsersService()
        {
            return new UsersService(FakeData.GetData());
        }

        public static ICommentsService GetCommentsService()
        {
            return new CommentsService(FakeData.GetData());
        }
    }
}
