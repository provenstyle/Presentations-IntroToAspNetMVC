using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Core.Logging;

namespace IntroToASPNetMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private ILogger logger; 
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            logger = CastleWindsorConfig.RegisterCastleWindsor();

            logger.Info("Started: IntroToAspnetMVC");
        }

        protected void Application_End()
        {
            logger.Info("Ended: IntroToAspnetMVC");
        }
    }
}
