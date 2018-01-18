namespace Teleimot.Server.Api.Tests.Setups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Teleimot.Data.Contracts;
    using Moq;

    public class FakeData
    {
        public static ITeleimotData GetData()
        {
            var data = new Mock<ITeleimotData>();

            data.Setup(x => x.Users)
                .Returns(() =>
                {
                    return Repositories.GetUsersRepository();
                });

            data.Setup(x => x.Comments)
                .Returns(() =>
                {
                    return Repositories.GetCommentsRepository();
                });

            return data.Object;
        }
    }
}
