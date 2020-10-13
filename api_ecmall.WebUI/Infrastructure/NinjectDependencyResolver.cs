using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Web.Common.WebHost;
using Ninject.Web.WebApi;
using System.Web.Http.Dependencies;
using Ninject.Syntax;
using System.Diagnostics.Contracts;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Concrete;
using System.Data.Entity;
using api_ecmall.WebUI.Settings;

namespace api_ecmall.WebUI.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private IKernel kernel;
        /// <summary>
        /// 
        /// </summary>
        public static NinjectDependencyResolver Current
        {
            get
            {
                var container = new NinjectDependencyResolver();
                container.Initing();
                container.Binding();
                return container;
            }
        }
        void Initing()
        {
            kernel = new StandardKernel();
        }
        void Binding()
        {
            //kernel.Bind<IOrderRepository>().To<OrderRepository>();
            //kernel.Bind<IHttpClientSF>().To<HttpClientSF>();
            kernel.Bind<IEcmOrderRepository>().To<EcmOrderRepository>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<IRabbitMQHelper>().To<RabbitMQHelper>().InSingletonScope();
            kernel.Bind<IlogsRspository>().To<logsRspository>();
            kernel.Bind<ILog4netHelper>().To<Log4netHelper>();
            kernel.Bind<ICustomsRepository>().To<CustomsRepository>();
            //kernel.Bind<IlogsRspository>().To<logsRspository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IPayOrderRepository>().To<PayOrderRepository>();
            kernel.Bind<IWarehouseRepository>().To<WarehouseRepository>();
            kernel.Bind<ISetting>().To<Setting>().InSingletonScope();
            kernel.Bind<IAlipayRepository>().To<AlipayRepository>();
            kernel.Bind<IpayExInfoRepository>().To<payExInfoRepository>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot root;
        /// <summary>
        /// 
        /// </summary>
        public NinjectDependencyScope()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        public NinjectDependencyScope(IResolutionRoot root)
        {
            this.root = root;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            try
            {
                return root.TryGet(serviceType);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.root.GetAll(serviceType);
            }
            catch (Exception ex)
            {
                return new List<object>();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            var disposable = this.root as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
            this.root = null;
        }
    }
}