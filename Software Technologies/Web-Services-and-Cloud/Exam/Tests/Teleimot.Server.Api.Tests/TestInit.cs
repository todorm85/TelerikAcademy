namespace Teleimot.Server.Api.Tests
{
    using System;
    using System.Reflection;
    using Api;
    using Config;
    using Common.Constants;
    using Data.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;
    using Setups;
    using Data.Models;
    using Data;
    using Services.Data.Contracts;

    [TestClass]
    public class TestInit
    {
        [AssemblyInitialize]
        public static void Init(TestContext testContext)
        {
            NinjectConfig.BindRepositoriesInterfaces = new Action<IKernel>(kernel =>
            {
                kernel.Bind<IRepository<User>>().ToConstant(Repositories.GetUsersRepository());
                kernel.Bind<IRepository<Comment>>().ToConstant(Repositories.GetCommentsRepository());
                kernel.Bind<ITeleimotData>().ToConstant(FakeData.GetData());
                kernel.Bind<ICommentsService>().ToConstant(Services.GetCommentsService());

            });

            AutoMapperConfig.RegisterMappings(Assembly.Load(AssembliesConstants.ApiModelsAssemblyName));
        }
    }
}
