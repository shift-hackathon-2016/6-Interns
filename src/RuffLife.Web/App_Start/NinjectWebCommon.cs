using System.Web.Http;
using Ninject.Web.WebApi;
using RuffLife.Core.Repositories;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Core.Services;
using RuffLife.Core.Services.Interfaces;
using RuffLife.Data.Context;
using RuffLife.Data.Models;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RuffLife.Web.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(RuffLife.Web.NinjectWebCommon), "Stop")]

namespace RuffLife.Web
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

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
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<RuffLifeContext>().ToSelf();

            kernel.Bind<IOwnerRepository>().To<OwnerRepository>();
            kernel.Bind<IDogRepository>().To<DogRepository>();
            kernel.Bind<IWalkerRepository>().To<WalkerRepository>();
            kernel.Bind<IWalkRepository>().To<WalkRepository>();


            kernel.Bind<IOwnerService>().To<OwnerService>();
            kernel.Bind<IDogService>().To<DogService>();
            kernel.Bind<IWalkerService>().To<WalkerService>();
            kernel.Bind<IWalkService>().To<WalkService>();
        }        
    }
}
