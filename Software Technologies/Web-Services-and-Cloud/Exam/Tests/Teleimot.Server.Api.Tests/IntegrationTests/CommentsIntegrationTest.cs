namespace Teleimot.Server.Api.Tests.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Api;
    using MyTested.WebApi;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommentsIntegrationTest
    {
        [TestMethod]
        public void GetCommentsByUserShouldReturnUnauthorizedWhenUserIsNotAuthorized()
        {
            MyWebApi.Server().Working<Startup>()
                .WithHttpRequestMessage(r => r
                .WithMethod(HttpMethod.Get)
                .WithRequestUri("/api/Comments/ByUser/TestUser1"))
                .ShouldReturnHttpResponseMessage()
                .WithStatusCode(HttpStatusCode.Unauthorized);
        }
    }
}
