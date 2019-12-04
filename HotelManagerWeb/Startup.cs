using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelManagerWeb.Startup))]
namespace HotelManagerWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
