[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(InmuebleVenta.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(InmuebleVenta.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace InmuebleVenta.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using InmuebleVenta.Entities.IRepositories;
    using InmuebleVenta.Persistence.Repositories;

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
            kernel.Bind<IUnityOfWork>().To<UnityOfWork>();

            kernel.Bind<IBoletaRepository>().To<BoletaRepository>();

            kernel.Bind<IClienteRepository>().To<ClienteRepository>();

            kernel.Bind<IComprobanteRepository>().To<ComprobanteRepository>();

            kernel.Bind<IContratoAlquilerRepository>().To<ContratoAlquilerRepository>();
            kernel.Bind<IContratoRepository>().To<ContratoRepository>();
            kernel.Bind<IContratoReservaRepository>().To<ContratoReservaRepository>();
            kernel.Bind<IContratoVentaRepository>().To<ContratoVentaRepository>();
            kernel.Bind<IDepartamentoRepository>().To<DepartamentoRepository>();
            kernel.Bind<IDistritoRepository>().To<DistritoRepository>();
            kernel.Bind<IEmpleadoRepository>().To<EmpleadoRepository>();
            kernel.Bind<IFacturaRepository>().To<FacturaRepository>();
            kernel.Bind<IInmuebleRepository>().To<InmuebleRepository>();
            kernel.Bind<IPropietarioRepository>().To<PropietarioRepository>();
            kernel.Bind<IProvinciaRepository>().To<ProvinciaRepository>();
            kernel.Bind<ITipoInmuebleRepository>().To<TipoInmuebleRepository>();
            kernel.Bind<IUbigeoRepository>().To<UbigeoRepository>();
            kernel.Bind<IVisitaRepository>().To<VisitaRepository>();
        }        
    }
}
