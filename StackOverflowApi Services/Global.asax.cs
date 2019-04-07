using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using RestServices.App_Start;
using RestServices.App_Start.AutoMapper;

namespace RestServices
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private WindsorContainer _container;
        protected void Application_Start()
        {
            _container = new WindsorContainer();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AutoMapperConfiguration.Configure();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bootstrapper.Initialize(_container);
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(_container));
        }
    }
}
