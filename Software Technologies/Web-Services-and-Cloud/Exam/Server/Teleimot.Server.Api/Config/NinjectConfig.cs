namespace Teleimot.Server.Api.Config
{
    using System;
    using System.Web;
    using Common.Constants;
    using Data;
    using Data.Contracts;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    public static class NinjectConfig 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        public static Action<IKernel> BindRepositoriesInterfaces = kernel =>
        {
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            kernel.Bind<ITeleimotData>().To<TeleimotData>();

            kernel.Bind(b => b.From(AssembliesConstants.DataServicesAssemblyName)
                .SelectAllClasses()
                .BindDefaultInterface());
        };

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {
            BindRepositoriesInterfaces(kernel);

            kernel.Bind<IDbContext>().To<TeleimotDbContext>();

            kernel.Bind(b => b.From(AssembliesConstants.CommonAssemblyName)
                .SelectAllClasses()
                .BindDefaultInterface());

            kernel.Bind(b => b.From(AssembliesConstants.WcfAssemblyName)
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}
