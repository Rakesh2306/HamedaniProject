using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HamedaniProject.Startup))]
namespace HamedaniProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
