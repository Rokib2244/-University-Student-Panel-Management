using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityManagementMVCWebApp.Startup))]
namespace UniversityManagementMVCWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
