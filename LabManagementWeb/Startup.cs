using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LabManagementWeb.Startup))]
namespace LabManagementWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
