[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FaleMaisDDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FaleMaisDDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace FaleMaisDDD.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using FaleMaisDDD.Domain.Interfaces.Repositories;
    using FaleMaisDDD.Infra.Data;
    using FaleMaisDDD.Infra.Repositories;
    using FaleMaisDDD.Domain.Interfaces.Services;
    using FaleMaisDDD.Business.Services;

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
                kernel.Bind<IAdministradorRepository>().To<AdministradorRepository>();
                kernel.Bind<DataContext>().To<DataContext>();
                kernel.Bind<IPlanoRepository>().To<PlanoRepository>();
                kernel.Bind<IPrecoRepository>().To<PrecoRepository>();
                kernel.Bind<IDDDRepository>().To<DDDRepository>();
                kernel.Bind<ICalculoService>().To<CalculoService>();
                kernel.Bind<IPlanoService>().To<PlanoService>();
                kernel.Bind<IPrecoService>().To<PrecoService>();
                kernel.Bind<IDDDService>().To<DDDService>();
                kernel.Bind<IAdministradorService>().To<AdministradorService>();

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
        private static void RegisterServices(IKernel kernel)
        {

        }        
    }
}
