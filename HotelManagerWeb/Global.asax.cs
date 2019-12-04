using Common;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HotelManagerWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InjectContainer container = new InjectContainer();
            container.Register("IRepository", "Repository");
            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory(container));
        }
    }
}
