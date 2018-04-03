using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PizzariaWebApp.Startup))]
namespace PizzariaWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
