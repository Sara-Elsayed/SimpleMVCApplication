using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleAuthProject.Startup))]
namespace SimpleAuthProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
