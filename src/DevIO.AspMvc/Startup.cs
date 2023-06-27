using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevIO.AspMvc.Startup))]
namespace DevIO.AspMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
