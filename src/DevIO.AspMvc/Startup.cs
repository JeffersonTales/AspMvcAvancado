using DevIO.AspMvc.App_Start;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartupAttribute(typeof(DevIO.AspMvc.Startup))]
namespace DevIO.AspMvc {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            
            ConfigureAuth(app);

            DependencyInjectionConfig.RegisterDIContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
