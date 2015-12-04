namespace Teleimot.Server.Api.Tests.Setups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts;
    using Moq;

    public class FakeDbContext
    {
        public static IDbContext GetFakeContext()
        {
            var data = new Mock<IDbContext>();

            return data.Object;
        }
    }
}
